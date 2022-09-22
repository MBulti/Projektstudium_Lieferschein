#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace App_Lieferschein.DependencyServices
{
    public partial class SaveService
    {
        public async partial void SaveAndView(string filename, string contentType, MemoryStream stream)
        {
            StorageFile stFile;
            string extension = Path.GetExtension(filename);
            IntPtr windowHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;

            FileSavePicker savePicker = new();
            savePicker.DefaultFileExtension = ".pdf";
            savePicker.SuggestedFileName = filename;
            savePicker.FileTypeChoices.Add("PDF", new List<string>() { ".pdf" });
            WinRT.Interop.InitializeWithWindow.Initialize(savePicker, windowHandle);
            stFile = await savePicker.PickSaveFileAsync();

            if (stFile != null)
            {
                using (var zipStream = await stFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    using Stream outstream = zipStream.AsStreamForWrite();
                    outstream.SetLength(0);
                    byte[] buffer = stream.ToArray();
                    outstream.Write(buffer, 0, buffer.Length);
                    outstream.Flush();
                }
                await Windows.System.Launcher.LaunchFileAsync(stFile);
            }
        }
    }
}
