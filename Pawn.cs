using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessScore
{
    /*
     * CheckPawn fonksiyonu, tehdit altında olup olmadığı kontrol edilen taşın, piyon tarafından tehdit edilip edilmediğini kontrol eder.
     * Tehdit edilmiyorsa taşın puanını, tehdit ediliyorsa taşın puanının yarısını döner.
     */
    internal class Pawn
    {

        public static double CheckPawn(string element, string boardElement, int i, int j, double score, string[,] board)
        {
            /*
             * Taşın konumuna göre, sağ çaprazında veya sol çaprazında karşı takımın piyonunun olup olmadığını kontrol eder.
             * 
             * Burada beyaz ve siyah taşların konumu önemlidir. 
             * Satranç tahtası iki boyutlu incelendiğinde:
             * *******  Siyah taşlar tahtanın yukarı kısmında, beyaz taşlar ise tahtanın aşağı kısmında yer alacağı varsayılmıştır. *******
             */

            if (boardElement.Contains("b"))
            {
                if(j != 0 && j != 7 && i != 7)
                {
                    if (board[i+1, j-1].Equals(boardElement))
                        return score / 2;
                    else if (board[i+1, j+1].Equals(boardElement))
                        return score / 2;
                }else if(j == 0 && i != 7)
                {
                    if (board[i+1, j+1].Equals(boardElement))
                        return score / 2;
                }else if(j == 7 && i != 7)
                {
                    if (board[i+1, j-1].Equals(boardElement))
                        return score / 2;
                }
            }
            else
            {
                if (j != 0 && j != 7 && i != 0)
                {
                    if (board[i-1, j-1].Equals(boardElement))
                        return score / 2;
                    else if (board[i-1, j+1].Equals(boardElement))
                        return score / 2;
                }
                else if (j == 0 && i != 0)
                {
                    if (board[i-1, j+1].Equals(boardElement))
                        return score / 2;
                }
                else if (j == 7 && i != 0)
                {
                    if (board[i-1, j-1].Equals(boardElement))
                        return score / 2;
                }
            }

            return score;
        }
    }
}
