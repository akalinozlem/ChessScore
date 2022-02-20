using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessScore
{
    /*
     * CheckKnight fonksiyonu, tehdit altında olup olmadığı kontrol edilen taşın, at tarafından tehdit edilip edilmediğini kontrol eder.
     * Tehdit edilmiyorsa taşın puanını, tehdit ediliyorsa taşın puanının yarısını döner.
     *
     * Bu fonksiyondaki double değişkenlerinin eşitliği "==" ile değil, aralarındaki farkın 0.0000001'den küçük olup olmadığına bakılarak kontrol edilmiştir.
     * Bunun sebebi, double değişkenlerinde virgülden sonra 7'den sonraki basamaklarında olası bir yuvarlama sonucunda "==" mantığının bozulmasının önüne geçilmek istenmesidir.
     */
    internal class Knight
    {

        private static int i;
        private static int j;
        private static string boardElement;
        private static string[,] board;
        private static double score;

        // Taşımızın pozisyonuna göre, at tarafından tehdit edilebilecek her kareye bakılıyor.
        public static double CheckKnight(string boardElement, int i, int j, double score, string[,] board)
        {
            Knight.i = i;
            Knight.j = j;
            Knight.boardElement = boardElement;
            Knight.score = score;
            Knight.board = board;

            double controlScore = score;


                if (j == 0 || j == 1)
                {
                    if(i == 0)
                    {
                        score = thirdCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = fourthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;

                        if (j == 1)
                        {
                            score = secondCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                        }
                    }
                    else if(i == 1)
                    {
                        score = thirdCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = fourthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = fifthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;

                        if (j == 1)
                        {
                            score = secondCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                        }
                    }
                    else if(i == 6)
                    {
                        score = fourthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = fifthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = sixthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;

                        if(j == 1)
                        {
                            score = seventhCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                        }
                    }
                    else if(i == 7)
                    {
                        score = fifthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = sixthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;

                        if (j == 1)
                        {
                            score = seventhCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                        }
                    }
                    else
                    {
                        score = thirdCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = fourthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = fifthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = sixthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;

                        if (j == 1)
                        {
                            score = secondCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                            score = seventhCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                        }
                    }
                }else if(j == 6 || j == 7)
                {
                    if(i == 0)
                    {
                        score = firstCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = secondCorner();
                        if ((controlScore - score > 0.000001))
                            return score;

                        if(j == 6)
                        {
                            score = thirdCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                        }
                    }else if(i == 1)
                    {
                        score = firstCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = secondCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = eighthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;

                        if(j == 6)
                        {
                            score = thirdCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                        }
                    }else if(i == 6)
                    {
                        score = firstCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = seventhCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = eighthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;

                        if(j == 6)
                        {
                            score = sixthCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                        }
                    }else if(i == 7)
                    {
                        score = seventhCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = eighthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;

                        if(j == 6)
                        {
                            score = sixthCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                        }

                    }
                    else
                    {
                        score = firstCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = seventhCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = seventhCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = eighthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;

                        if(j == 6)
                        {
                            score = thirdCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                            score = sixthCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                        }
                    }
                }
                else
                {
                    if(i == 0 || i == 1)
                    {
                        score = firstCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = secondCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = thirdCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = fourthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;

                        if(i == 1)
                        {
                            score = fifthCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                            score = eighthCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                        }

                    }
                    else if(i == 6 || i == 7)
                    {
                        score = fifthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = sixthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = seventhCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = eighthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;

                        if(i == 6)
                        {
                            score = fifthCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                            score = fourthCorner();
                            if ((controlScore - score > 0.000001))
                                return score;
                        }
                    }
                    else
                    {
                        score = firstCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = secondCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = thirdCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = fourthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = fifthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = sixthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = seventhCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                        score = eighthCorner();
                        if ((controlScore - score > 0.000001))
                            return score;
                    }
                }
          


            return score;
        }

        #region Functions

        
        //  1. köşede rakip takımın atı var mı kontrolü
        private static double firstCorner()
        {
            if (board[i + 1, j - 2].Equals(boardElement))
                return score / 2;
            else
                return score;
        }
        //  2. köşede rakip takımın atı var mı kontrolü
        private static double secondCorner()
        {
            if (board[i + 2, j - 1].Equals(boardElement))
                return score / 2;
            else
                return score;
        }
        //  3. köşede rakip takımın atı var mı kontrolü
        private static double thirdCorner()
        {
            if (board[i + 2, j +1].Equals(boardElement))
                return score / 2;
            else
                return score;
        }
        //  4. köşede rakip takımın atı var mı kontrolü
        private static double fourthCorner()
        {
            if (board[i + 1 , j + 2].Equals(boardElement))
                return score / 2;
            else
                return score;
        }
        //  5. köşede rakip takımın atı var mı kontrolü
        private static double fifthCorner()
        {
            if (board[i - 1, j + 2].Equals(boardElement))
                return score / 2;
            else
                return score;
        }
        //  6. köşede rakip takımın atı var mı kontrolü
        private static double sixthCorner()
        {
            if (board[i - 2, j + 1].Equals(boardElement))
                return score / 2;
            else
                return score;
        }
        //  7. köşede rakip takımın atı var mı kontrolü
        private static double seventhCorner()
        {
            if (board[i - 2, j - 1].Equals(boardElement))
                return score / 2;
            else
                return score;
        }
        //  8. köşede rakip takımın atı var mı kontrolü
        private static double eighthCorner()
        {
            if (board[i - 1, j - 2].Equals(boardElement))
                return score / 2;
            else
                return score;
        }
        #endregion


        /*
         *   Taşa göre köşelerin konumu
         * 
         *          7       6
         *      8               5
         *             taş
         *      1               4
         *          2       3
         */


    }
}
