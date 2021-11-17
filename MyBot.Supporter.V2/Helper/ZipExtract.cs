﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBot.Supporter.V2.Helper
{
    public class ZipExtract
    {
        public void Extract(string fileName)
        {
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
            string destinationDirectoryFullPath = di.FullName;
            using (var strm = File.OpenRead(fileName))
            using (ZipArchive archive = new ZipArchive(strm))
                foreach (ZipArchiveEntry file in archive.Entries)
                {
                    string completeFileName = Path.GetFullPath(Path.Combine(destinationDirectoryFullPath, file.FullName));

                    if (!completeFileName.StartsWith(destinationDirectoryFullPath, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new IOException("Trying to extract file outside of destination directory. See this link for more info: https://snyk.io/research/zip-slip-vulnerability");
                    }

                    if (file.Name == "")
                    {// Assuming Empty for Directory
                        Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                        continue;
                    }
                    try
                    {
                        file.ExtractToFile(completeFileName, true);
                    }
                    catch
                    {

                    }
                }
            File.Delete(fileName);
        }
    }
}
