using System;
using System.Runtime.InteropServices;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    public struct MTLCaptureManager
    {
        private static ObjCClass s_class = new ObjCClass("MTLCaptureManager");

        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCaptureManager device) => device.NativePtr;
        public MTLCaptureManager(IntPtr nativePtr) => NativePtr = nativePtr;

        public static MTLCaptureManager sharedCaptureManager
            => objc_msgSend<MTLCaptureManager>(s_class, sel_sharedCaptureManager);

        public Bool8 isCapturing => bool8_objc_msgSend(NativePtr, sel_isCapturing);

        public Bool8 startCaptureWithDescriptor(MTLCaptureDescriptor descriptor)
        {
            Bool8 ret = bool8_objc_msgSend(NativePtr, sel_startCaptureWithDescriptor, descriptor, out NSError error);
            if (error.NativePtr != IntPtr.Zero)
            {
                throw new Exception(error.localizedDescription);
            }
            return ret;
        }

        public void stopCapture() => objc_msgSend(NativePtr, sel_stopCapture);

        private static readonly Selector sel_sharedCaptureManager = "sharedCaptureManager";
        private static readonly Selector sel_startCaptureWithDescriptor = "startCaptureWithDescriptor:error:";
        private static readonly Selector sel_stopCapture = "stopCapture";
        private static readonly Selector sel_isCapturing = "isCapturing";
    }
}
