using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessScore
{
    internal class King
    {
        /*
         * CheckKing fonksiyonu, tehdit altında olup olmadığı kontrol edilen taşın, kral tarafından tehdit edilip edilmediğini kontrol eder.
         * Tehdit edilmiyorsa taşın puanını, tehdit ediliyorsa taşın puanının yarısını döner.
         */
        public static double CheckKing(int i, int j, string boardElement, double score, string[,] board)
        {
            //Taşın konumuna görei etrafındaki tüm kareler kontrol ediliyor.

            if (i != 0 && j != 0 && i != 7 && j != 7 )
            {
                if (board[i+1, j].Equals(boardElement))
                    return score / 2;
                else if (board[i+1, j+1].Equals(boardElement))
                    return score / 2;
                else if (board[i, j+1].Equals(boardElement))
                    return score / 2;
                else if (board[i-1, j+1].Equals(boardElement)) 
                    return score / 2;
                else if (board[i-1, j].Equals(boardElement))
                    return score / 2;
                else if (board[i-1, j-1].Equals(boardElement))
                    return score / 2;
                else if (board[i, j-1].Equals(boardElement))
                    return score / 2;
                else if (board[i+1, j-1].Equals(boardElement))
                    return score / 2;
            }
            else
            {
                if(i == 0)
                {
                    if(j == 0)
                    {
                        if (board[i+1, j].Equals(boardElement))
                            return score / 2;    
                        else if (board[i+1, j+1].Equals(boardElement))
                            return score / 2;
                        else if (board[i, j+1].Equals(boardElement))
                            return score / 2;
                    }else if(j == 7)
                    {
                        if (board[i+1, j].Equals(boardElement))
                            return score / 2;
                        else if (board[i+1, j-1].Equals(boardElement))
                            return score / 2;
                        else if (board[i, j-1].Equals(boardElement))
                            return score / 2;
                    }
                    else
                    {
                        if (board[i, j-1].Equals(boardElement))
                            return score / 2;
                        else if (board[i+1, j-1].Equals(boardElement))
                            return score / 2;
                        else if (board[i+1, j].Equals(boardElement))
                            return score / 2;
                        else if (board[i+1, j+1].Equals(boardElement))
                            return score / 2;
                        else if (board[i, j+1].Equals(boardElement))
                            return score / 2;
                    }


                }
                else if (i == 7)
                {
                    if (j == 0)
                    {
                        if (board[i-1, j].Equals(boardElement))
                            return score / 2;
                        else if (board[i-1, j+1].Equals(boardElement))
                            return score / 2;
                        else if (board[i, j+1].Equals(boardElement))
                            return score / 2;
                    }else if(j == 7){
                        if (board[i, j-1].Equals(boardElement))
                            return score / 2;
                        else if (board[i-1, j-1].Equals(boardElement))
                            return score / 2;
                        else if (board[i-1, j].Equals(boardElement))
                            return score / 2;
                    }
                    else
                    {
                        if (board[i, j-1].Equals(boardElement))
                            return score / 2;
                        else if (board[i-1, j-1].Equals(boardElement))
                            return score / 2;
                        else if (board[i-1, j].Equals(boardElement))
                            return score / 2;
                        else if (board[i-1, j+1].Equals(boardElement))
                            return score / 2;
                        else if (board[i, j+1].Equals(boardElement))
                            return score / 2;
                    }
                }
                else if(j == 0)
                {

                    if (board[i+1, j].Equals(boardElement))
                        return score / 2;
                    else if (board[i+1, j+1].Equals(boardElement))
                        return score / 2;
                    else if (board[i, j+1].Equals(boardElement))
                        return score / 2;
                    else if (board[i-1, j+1].Equals(boardElement))
                        return score / 2;
                    else if (board[i-1, j].Equals(boardElement))
                        return score / 2;


                }
                else if (j == 7)
                {
                    if (board[i-1, j].Equals(boardElement))
                        return score / 2;
                    else if (board[i-1, j-1].Equals(boardElement))
                        return score / 2;
                    else if (board[i, j-1].Equals(boardElement))
                        return score / 2;
                    else if (board[i+1, j-1].Equals(boardElement))
                        return score / 2;
                    else if (board[i+1, j].Equals(boardElement))
                        return score / 2;
                }
            }

            return score;
        }
    }
}
