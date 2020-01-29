using System;
using System.Runtime.InteropServices;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    public struct MTLCaptureDescriptor
    {
        private static ObjCClass s_class = new ObjCClass("MTLCaptureDescriptor");

        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCaptureDescriptor device) => device.NativePtr;

        public static MTLCaptureDescriptor Create() => s_class.AllocInit<MTLCaptureDescriptor>();

        public void setCaptureObject(MTLDevice captureObject)
            => objc_msgSend(NativePtr, sel_setCaptureObject, captureObject);

        public void setCaptureObject(MTLCommandQueue captureObject)
            => objc_msgSend(NativePtr, sel_setCaptureObject, captureObject);

        // TODO: Implement MTLCaptureScope
        // public void setCaptureObject(MTLCaptureScope captureObject)
        //     => objc_msgSend(NativePtr, sel_setCaptureObject, captureObject);

        public void Release() => release(NativePtr);

        private static readonly Selector sel_init = "init";
        private static readonly Selector sel_setCaptureObject = "setCaptureObject:";
    }
}
