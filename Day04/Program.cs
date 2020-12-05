using System;
using System.Security.Cryptography;
using System.Text;

internal class Day04
{
    private static void Main()
    {
        const int NUM_ZEROS = 5;       // make it 6 for part 2   

        string puzzleinput = "iwrupvqb";
        bool found = false;
        int num = 0;

        while (!found)
        {
            num++;
            var source = puzzleinput + num;

            // Code taken from: https://riptutorial.com/csharp/example/9341/md5
            // Creates an instance of the default implementation of the MD5 hash algorithm.
            using (var md5Hash = MD5.Create())
            {
                // Byte array representation of source string
                var sourceBytes = Encoding.UTF8.GetBytes(source);

                // Generate hash value(Byte Array) for input data
                var hashBytes = md5Hash.ComputeHash(sourceBytes);

                // Convert hash byte array to string
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                // Output the MD5 hash
                //Console.WriteLine("The MD5 hash of " + source + " is: " + hash);    // uncomment if you want to see all trials

                found = true;
                for (int i = 0; i < NUM_ZEROS; i++)               
                    if (hash[i] != '0') found = false; 
                
                if(found) Console.WriteLine("The MD5 hash of " + source + " is: " + hash); 
            }
        }
    }
}