using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessScore
{
    /*
     * CheckBishop fonksiyonu, tehdit altında olup olmadığı kontrol edilen taşın, fil tarafından tehdit edilip edilmediğini kontrol eder.
     * Tehdit edilmiyorsa taşın puanını, tehdit ediliyorsa taşın puanının yarısını döner.
     * 
     * Bu fonksiyondaki double değişkenlerinin eşitliği "==" ile değil, aralarındaki farkın 0.0000001'den küçük olup olmadığına bakılarak kontrol edilmiştir.
     * Bunun sebebi, double değişkenlerinde virgülden sonra 7'den sonraki basamaklarında olası bir yuvarlama sonucunda "==" mantığının bozulmasının önüne geçilmek istenmesidir.
     */
    internal class Bishop : ChessVariables
    {
        

        public static double CheckBishop()
        {

            double controlScore = score; //Kontrol değişkeni

            //Taş 1 veya 2. bölgede mi yoksa 3 veya 4. bölgede mi diye kontrolü sağlanır

            if (j <= (7 - i))
            {
                //Taş 1 veya 2. bölgededir.

                //Taşın bulunduğu yeri kesen doğrular için, 45 derecelik doğruda fil var mı kontrolü

                score = RightRotatePlane((i + j), 0, (j + i), i, j, boardElement, element, score, board);

                if ((controlScore-score) > 0.0000001)
                    return score;

                //Eğer taş 1. bölgedeyse, taşın bulunduğu yeri kesen doğrular için, 135 derecelik doğruda fil var mı kontrolü
                if (i > j)
                {
                    // i > j ise taş 1. bölgededir.

                    score = LeftRotatePlane((i - j), 0, (7 - i + j), i, j, boardElement, element, score, board);

                    if ((controlScore - score) > 0.0000001)
                        return score;

                }
                else
                {
                    // j >= i ise taş 2. bölgededir.

                    score = LeftRotatePlane(0, (j - i), 7, i, j, boardElement, element, score, board);

                    if ((controlScore  - score ) > 0.0000001) 
                        return score;                                 

                }
            }
            else
            {
                //Taş 3 veya 4. bölgededir.

                //Taşın bulunduğu yeri kesen doğrular için, 45 derecelik doğruda fil var mı kontrolü

                #region Alt üçgen 45 derecelik doğrular

                score = RightRotatePlane(7, (j - (7 - i)), 7, i, j, boardElement, element, score, board);

                if ((controlScore - score) > 0.0000001)
                    return score;

                
                #endregion


                //Eğer taş 3. bölgedeyse, taşın bulunduğu yeri kesen doğrular için, 135 derecelik doğruda fil var mı kontrolü
                if (j >= i)
                {
                    // j > i ise taş 3. bölgededir.

                    //3. Bölgedeki 135 derecelik doğruların kontrolü

                    score = LeftRotatePlane(0, (j - i), 7, i, j, boardElement, element, score, board);

                    if ((controlScore  - score) > 0.0000001)
                        return score;
                }
                else
                {
                    // j >= i ise taş 4. bölgededir.
                    score = LeftRotatePlane((i - j), 0, (7 - i + j), i, j, boardElement, element, score, board);

                    if ((controlScore  - score) > 0.0000001)
                        return score;

                }

            }

            return score;
        }

        // LeftRotatePlane fonksiyonunda, taşın bulunduğu eksenlerden, 135 derecelik eksende fil var mı kontrolü gerçekleştirilir.
        public static double LeftRotatePlane(int xInitial, int yInitial, int boundary, int i, int j, string boardElement, string element, double score, string[,] board)
        {
            int x, y;

            double controlScore = score;

            #region 135 derecelik doğrular
            for (x = xInitial, y = yInitial; y <= boundary; x++, y++)
            {
                if (board[x, y].Equals("--"))
                {
                    continue;
                }
                else if (board[x, y].Equals(boardElement))
                {
                    //Bu if'e giriyorsa, karşı takımdan bir fil, baktığımız taşı tehdit edecek bir konumda demektir.
                    //Fil ile taşımız arasında başka bir taşın olup olmadığının kontrolü
                    if (y > j)
                    {

                        score = CheckBarrierLeftRotate(i, j, y, element, boardElement, score,board);

                    }
                    else if (y < j)
                    {

                        score = CheckBarrierLeftRotate(x, y, j, element, boardElement, score, board);

                    }

                    if ((controlScore - score) < 0.000001)
                    {
                        //Fil ile taşımız arasında engel olduğu durum
                        continue;
                    }
                    else
                    {
                        //Kod buraya geliyorsa, fil ile taşımız arasında bir engel yok, taşımız fil tarafından tehdit altında demektir.
                        return score;
                    }
                }
            }
            #endregion



            return score;
        }

        // RightRotatePlane fonksiyonunda, taşın bulunduğu eksenlerden, 45 derecelik eksende fil var mı kontrolü gerçekleştirilir.
        public static double RightRotatePlane(int xInitial, int yInitial, int boundary, int i, int j, string boardElement, string element, double score, string[,] board)
        {
            int x, y;

            double controlScore = score;

            #region 45 derecelik doğrular
            for (x = xInitial, y = yInitial; y <= boundary; x--, y++)
            {
                if (board[x, y].Equals("--"))
                {
                    continue;
                }
                else if (board[x, y].Equals(boardElement))
                {
                    //Bu if'e giriyorsa, karşı takımdan bir fil, baktığımız taşı tehdit edecek bir konumda demektir.
                    //Fil ile taşımız arasında başka bir taşın olup olmadığının kontrolü
                    if (y > j)
                    {

                        score = CheckBarrierRightRotate(i, j, y, element, boardElement, score, board);

                    }
                    else if (y < j)
                    {

                        score = CheckBarrierRightRotate(x, y, j, element, boardElement, score, board);

                    }

                    if ((controlScore - score) < 0.000001)
                    {
                        //Fil ile taşımız arasında engel olduğu durum
                        continue;
                    }
                    else
                    {
                        //Kod buraya geliyorsa, fil ile taşımız arasında bir engel yok, taşımız fil tarafından tehdit altında demektir.
                        return score;
                    }
                }
            }
            #endregion



            return score;
        }

        // CheckBarrierRightRotate fonksiyonunda, 45 derecelik eksende duran fil ile taşımız arasında başka bir taş var mı kontrolü gerçekleştirilir.
        public static double CheckBarrierRightRotate(int i, int j, int z, string element, string boardElement , double score, string[,] board)
        {
            int controlVariable1, controlVariable2;
            for (controlVariable1 = i, controlVariable2 = j; controlVariable2 < z; controlVariable1--, controlVariable2++)
            {
                if (!board[controlVariable1, controlVariable2].Equals("--") && !board[controlVariable1, controlVariable2].Equals(element) && !board[controlVariable1, controlVariable2].Equals(boardElement))
                    return score;
                else
                    continue;
               
            }

            return score / 2;
        }

        // CheckBarrierLeftRotate fonksiyonunda, 135 derecelik eksende duran fil ile taşımız arasında başka bir taş var mı kontrolü gerçekleştirilir.
        public static double CheckBarrierLeftRotate(int i, int j, int z, string element, string boardElement, double score, string[,] board)
        {
            int controlVariable1, controlVariable2;
            for (controlVariable1 = i, controlVariable2 = j; controlVariable2 < z; controlVariable1++, controlVariable2++)
            {
                if (!board[controlVariable1, controlVariable2].Equals("--") && !board[controlVariable1, controlVariable2].Equals(element) && !board[controlVariable1, controlVariable2].Equals(boardElement))
                    return score;
                else
                    continue;

            }

            return score / 2;
        }
    }

    /*  Satranç tahtasının 1.,2.,3. ve 4. bölümleri.
     * 
           2   2   2   2   2   2   2   3
           1   2   2   2   2   2   3   3
           1   1   2   2   2   3   3   3
           1   1   1   2   3   3   3   3
           1   1   1   1   4   3   3   3
           1   1   1   4   4   4   3   3
           1   1   4   4   4   4   4   3
           1   4   4   4   4   4   4   4
     *  
     */

}
