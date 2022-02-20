/*
 *  Title: Verilen satranç taşları konumuna göre siyah ve beyaz takım için puan hesaplayan program
 *  Author: Özlem Akalın
 *  Last Changed Date: 20.02.2022
 */


#region Using
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
#endregion


namespace ChessScore
{
    internal class Program
    {
        private static string[,] board = new string[8, 8]; // Satranç tahtasının durumunun tutulduğu değişken
        static void Main(string[] args)
        {

            /*
             *  .exe uzantılı dosyamız ile aynı dizinde bulunan .txt uzantılı dosyaların isimleri kontrol ediliyor,
             *  eğer dosyanın ismi "board" ile başlıyorsa içeriği okunuyor.
            */
            List<String> fileNames = new List<string>();
            DirectoryInfo dInfo = new DirectoryInfo(AppContext.BaseDirectory.ToString());
            FileInfo[] files = dInfo.GetFiles("*.txt");
            string fileName;
            foreach (FileInfo file in files)
            {
                fileName = file.Name;
                if (fileName.Contains("board") && !fileName.Contains("Score"))
                    fileNames.Add(file.Name);
                else
                    continue;
            }


            /*
             * Bulunan her .txt uzantılı dosya için, dosyanın içeriği okunuyor 
             * ve okunan bilgiye göre toplam puan hesaplanıyor
             */
            foreach (var fname in fileNames)
            {
                    string[] lines = File.ReadAllLines(AppContext.BaseDirectory.ToString() + fname);
                    
                    // Dosyadan okunan bilgilerin iki boyutlu string değişkenine aktarılıyor
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] eachElement = lines[i].Split(" ");
                        for (int j = 0; j < eachElement.Length; j++)
                        {
                            board[i,j] = eachElement[j];
                        }
                    }

                    double finalScoreWhite = 0, finalScoreBlack = 0; // Beyaz ve siyah takımların toplam puanının tutulduğu değişkenler
                
                    // Gerekli kontroller yapıldıktan sonra her takımın toplam puanı hesaplanıyor
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (board[i, j].Contains("b"))
                                finalScoreWhite += Score.FinalScore(board[i, j], i, j, board);
                            else if (!board[i, j].Equals("--"))
                                finalScoreBlack += Score.FinalScore(board[i, j], i, j, board);
                        }

                    }

                //Sonuçlar, dosyanın ismi + "Score" (mesela board1Score) olacak şekilde ilgili dosyalara yazdırılıyor.
                string text = "Siyah Takim: " + finalScoreBlack+"\nBeyaz Takim: " + finalScoreWhite;

                _ = WriteScoreAsync(fname.Substring(0, fname.IndexOf('.')), text);

            }

        }

        private static async Task WriteScoreAsync(string fileName,string score)
        {
            await File.WriteAllTextAsync(fileName+"Score.txt", score);
        }

    }
}
