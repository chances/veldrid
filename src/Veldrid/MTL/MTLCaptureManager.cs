using System;

namespace Veldrid.MTL
{
    /// <summary>
    /// An object you use to capture Metal command data in your app.
    /// </summary>
    /// <remarks>
    /// See the Apple documentation for <see href="https://developer.apple.com/documentation/metal/frame_capture_debugging_tools">Frame Capture Debugging Tools</see>.
    /// </remarks>
    public class MTLCaptureManager
    {
        public static readonly Lazy<MTLCaptureManager> SharedCaptureManager = new Lazy<MTLCaptureManager>(GetSharedCaptureManager);

        private readonly MetalBindings.MTLCaptureManager _manager;

        /// <summary>
        /// A <see cref="Boolean"/> value that indicates whether Metal commands are being captured.
        /// </summary>
        public bool IsCapturing => _manager.isCapturing;

        public MTLCaptureManager()
        {
            _manager = MetalBindings.MTLCaptureManager.sharedCaptureManager;
        }

        /// <summary>
        /// Starts capturing any of your app’s Metal commands, with the capture session defined by a descriptor object.
        /// </summary>
        /// <param name="descriptor">A description of the capture session to create.</param>
        /// <returns>A <see cref="Boolean"/> value indicating whether the capture session was successfully started.</returns>
        /// <exception cref="VeldridException">Thrown when the capture session failed to start.</exception>
        public bool StartCapture(MTLCaptureDescriptor descriptor)
        {
            try {
                return _manager.startCaptureWithDescriptor(descriptor);
            }
            catch (Exception ex)
            {
                throw new VeldridException("Failed to start capture session", ex);
            }
        }

        /// <summary>
        /// Stops capturing Metal commands.
        /// </summary>
        public void StopCapture() => _manager.stopCapture();

        private static MTLCaptureManager GetSharedCaptureManager() => new MTLCaptureManager();
    }
}
