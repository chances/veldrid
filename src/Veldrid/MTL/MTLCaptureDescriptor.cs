using System;

namespace Veldrid.MTL
{
    /// <summary>
    /// A configuration for a Metal capture session.
    /// </summary>
    /// <remarks>
    /// See <see cref="MTLCaptureManager"/>.
    /// </remarks>
    public class MTLCaptureDescriptor
    {
        private MetalBindings.MTLCaptureDescriptor _descriptor;
        public static implicit operator MetalBindings.MTLCaptureDescriptor(MTLCaptureDescriptor descriptor) => descriptor._descriptor;

        /// <summary>
        /// Specify a <see cref="GraphicsDevice"/> object to capture commands in command buffers created on any command queues created by the device object.
        /// </summary>
        /// <param name="device"></param>
        /// <exception cref="VeldridException">Thrown when the <see cref="GraphicsDevice.BackendType"/> of <paramref name="device"/> is not <see cref="GraphicsBackend.Metal"/>.</exception>
        public MTLCaptureDescriptor(GraphicsDevice device)
        {
            if (device is MTLGraphicsDevice metalDevice)
            {
                _descriptor = new MetalBindings.MTLCaptureDescriptor();
                _descriptor.setCaptureObject(metalDevice.Device);
            }
            else
            {
                throw new VeldridException("Metal Frame Capture is only available with the Metal backend");
            }
        }

        /// <summary>
        /// Specify a <see cref="CommandList"/> object to capture commands in command buffers created by a specific command queue.
        /// </summary>
        /// <param name="commandList"></param>
        /// <exception cref="VeldridException">Thrown when the <see cref="GraphicsBackend"/> of <paramref name="commandList"/> is not <see cref="GraphicsBackend.Metal"/>.</exception>
        public MTLCaptureDescriptor(CommandList commandList)
        {
            if (commandList is MTLCommandList metalCommandList)
            {
                _descriptor = new MetalBindings.MTLCaptureDescriptor();
                _descriptor.setCaptureObject(metalCommandList.GraphicsDevice.CommandQueue);
            }
            else
            {
                throw new VeldridException("Metal Frame Capture is only available with the Metal backend");
            }
        }

        // TODO: Implement MTLCaptureScope
        /*
        /// <summary>
        /// Specify a <see cref="MTLCaptureScope"/> object to indirectly define which commands are captured.
        /// </summary>
        /// <param name="captureScope"></param>
        public MTLCaptureDescriptor(MTLCaptureScope captureScope)
        {
            _descriptor = new MetalBindings.MTLCaptureDescriptor();
            _descriptor.setCaptureObject(captureScope);
        }
        */
    }
}
