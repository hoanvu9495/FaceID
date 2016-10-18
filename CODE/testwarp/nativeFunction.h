#ifndef __NATIVE_FUNCTION_H__
#define __NATIVE_FUNCTION_H__

#if defined DLL_EXPORT
#define DLL __declspec(dllexport)
#else
#define DLL __declspec(dllimport)
#endif


extern "C"
{
	//CAPTURE VLW
	//DLL void initCapture();
	DLL void FT_init(void *&ptr);

}
#endif // __NATIVE_FUNCTION_H__