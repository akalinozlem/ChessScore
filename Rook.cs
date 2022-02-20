using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessScore
{
    /*
     * CheckRook fonksiyonu, tehdit altında olup olmadığı kontrol edilen taşın, kale tarafından tehdit edilip edilmediğini kontrol eder.
     * Tehdit edilmiyorsa taşın puanını, tehdit ediliyorsa taşın puanının yarısını döner.
     */
    internal class Rook : ChessVariables
    {
        public static double CheckRook()
        {
            #region CheckCastle
            
            int check = 0;

            //x ekseninin kontrolü 
            for (int e = 0; e < 8; e++)
            {

                if (board[i, e].Equals("--"))
                {
                    continue;
                }
                else if (board[i, e].Equals(boardElement))
                {

                    //Kaleyle bizim taşımız arasında bir taş var mı kontrolü
                    if (e < j)
                    {
                        for (int c = e; c < j; c++)
                        {
                            if (board[i, c].Equals("--") || board[i, c].Equals(element) || board[i, c].Equals(boardElement))
                            {
                                continue;
                            }
                            else
                            {
                                check = 1;
                                break;
                            }
                        }
                        if (check == 1)
                        {
                            //Buraya geliyorsa, taşımız ve bulunan kale arasında başka bir taş vardır demektir.
                            //Yani bu kale, bizim için sorun teşkil etmiyor.
                            continue;
                        }
                        else
                        {
                            //Kod buraya geliyorsa, kaleyle bizim taşımız arasında hiçbir taş yok demektir.
                            //O zaman kale, taşımız için tehdit oluşturuyor.
                            return score / 2;
                        }
                    }
                    else
                    {
                        for (int c = j; c < e; c++)
                        {
                            if (board[i, c].Equals("--") || board[i, c].Equals(element) || board[i, c].Equals(boardElement))
                            {
                                continue;
                            }
                            else
                            {
                                check = 1;
                                break;
                            }
                        }
                        if (check == 1)
                        {
                            //Buraya geliyorsa, taşımız ve bulunan kale arasında başka bir taş vardır demektir.
                            //Yani bu kale, bizim için sorun teşkil etmiyor.
                            continue;
                        }
                        else
                        {
                            //Kod buraya geliyorsa, aralarında hiçbir kaleyle bizim taşımız arasında hiçbir taş yok demektir.
                            //O zaman kale, taşımız için tehdit oluşturuyor.
                            return score / 2;
                        }
                    }
                }
            }


            check = 0;
            //y ekseninin kontrolü
            for (int b = 0; b < 8; b++)
            {
                if (board[b, j].Equals("--"))
                {
                    continue;
                }
                else if (board[b, j].Equals(boardElement))
                {

                    //Kaleyle bizim taşımız arasında bir taş var mı kontrolü
                    if (b < i)
                    {
                        for (int c = b; c < i; c++)
                        {
                            if (board[c, j].Equals("--") || board[c, j].Equals(element) || board[c, j].Equals(boardElement))
                            {
                                continue;
                            }
                            else
                            {
                                check = 1;
                                break;
                            }
                        }
                        if (check == 1)
                        {
                            //Buraya geliyorsa, taşımız ve bulunan kale arasında başka bir taş vardır demektir.
                            //Yani bu kale, bizim için sorun teşkil etmiyor.
                            continue;
                        }
                        else
                        {
                            //Kod buraya geliyorsa, aralarında hiçbir kaleyle bizim taşımız arasında hiçbir taş yok demektir.
                            //O zaman kale, taşımız için tehdit oluşturuyor.
                            return score / 2;
                        }
                    }
                    else
                    {
                        for (int c = i; c < b; c++)
                        {
                            if (board[c, j].Equals("--") || board[c, j].Equals(element) || board[c, j].Equals(boardElement))
                            {
                                continue;
                            }
                            else
                            {
                                check = 1;
                                break;
                            }
                        }
                        if (check == 1)
                        {
                            //Buraya geliyorsa, taşımız ve bulunan kale arasında başka bir taş vardır demektir.
                            //Yani bu kale, bizim için sorun teşkil etmiyor.
                            continue;
                        }
                        else
                        {
                            //Kod buraya geliyorsa, aralarında hiçbir kaleyle bizim taşımız arasında hiçbir taş yok demektir.
                            //O zaman kale, taşımız için tehdit oluşturuyor.
                            return score / 2;
                        }
                    }
                }
            }

            #endregion
            return score;
        }

    }
}
