using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class TextFileInFileRepository: ITextFileRepository
    {
        public void Create(TextFileModel file)
        {
            // Open the inventory.txt file in append mode
            using (StreamWriter sw = new StreamWriter("inventory.txt", true))
            {
                // Write the file details to the end of the file
                sw.WriteLine(file.FileName + "," + file.Data + "," + file.Author + "," + file.LastEditedBy + "," + file.LastUpdated);
            }
        }

        
        public void Edit( string fileName, TextFileModel file)
        {
            // Open the inventory.txt file
            var lines = File.ReadAllLines("inventory.txt");
            // Find the file to be updated
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(fileName))
                {
                    // Update the data of the file
                    lines[i] = file.FileName + "," + file.UploadedOn + "," + file.Data + ",";
                    // Update the LastUpdated and checksum in the inventory.txt
                    lines[i] = lines[i] + "," + file.LastUpdated + "," + file.Checksum;
                    break;
                }
            }
            // Write the updated data to the inventory.txt file
            File.WriteAllLines("inventory.txt", lines);
        }

        public void Share(string fileName)
        {
            // Open the acl.txt file in append mode
            using (StreamWriter sw = new StreamWriter("acl.txt", true))
            {
              
            }
        }

        public TextFileModel GetFile(string fileName)
        {
            // Read the inventory.txt file
            var lines = File.ReadAllLines("inventory.txt");
            // Find the requested file
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(fileName))
                {
                    // Split the line to get the file details
                    var fileDetails = lines[i].Split(',');
                    // Create a new File object
                    var file = new TextFileModel
                    {
                    
                        LastUpdated = DateTime.Parse(fileDetails[3]),
                        Checksum = fileDetails[4]
                    };

                    // Read the acl.txt file
                    var aclLines = File.ReadAllLines("acl.txt");
                    // Find the permissions for the requested file
                    for (int j = 0; j < aclLines.Length; j++)
                    {
                        if (aclLines[j].StartsWith(fileName))
                        {
                            // Split the line to get the file permissions
                            var aclDetails = aclLines[j].Split(':')[1].Split(',');
                            file.Permissions = aclDetails.ToList();
                            break;
                        }
                    }
                    return file;
                }
            }
            return null;
        }

        public TextFileModel GetTextFileModels(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(TextFileModel textFile)
        {
            throw new NotImplementedException();
        }
    }
}
