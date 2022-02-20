using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessScore
{
    /*
     * Bir taşın tehdit altında olup olmadığının kontrolü için gerekli değişkenlerin ayarlandığı fonksiyon
     */
    public class ChessVariables
    {
        protected static string element;    //Tehdit altında olup olmadığını kontrol ettiğimiz taş
        protected static string boardElement;   //Hangi taş tarafından tehdit edildiği
        protected static int i;     //Taşımızın y ekseni konumu
        protected static int j;     //Taşımızın x ekseni konumu
        protected static double score;      //Taşımızın puanı
        protected static string[,] board;       //Satranç tahtası anlık pozisyon bilgileri

        public void setElement(string element)
        {
            ChessVariables.element = element;
        }
        public void setBoardElement(string boardElement)
        {
            ChessVariables.boardElement = boardElement;
        }
        public void setX(int i)
        {
            ChessVariables.i = i;
        }
        public void setY(int j)
        {
            ChessVariables.j = j;
        }
        public void setScore(double score)
        {
            ChessVariables.score = score;
        }
        public void setBoard(string[,] board)
        {
            ChessVariables.board = board;
        }

        

    }
}
