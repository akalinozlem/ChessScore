using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessScore
{
    internal class Score : ChessVariables
    {

        /*
         * Bir taşın tehdit altında olup olmadığını kontrol eder.
         * Taş tehdit altında değilse kendi puanını, tehdit altındaysa puanının yarısını döner.
         */
        public static double FinalScore(string element, int i, int j, string[,] board)
        {

            double score = 0, finalScore = 0;

            string opponent, boardElement; //opponent: rakibin renk bilgisini; boardElement: tehdit eden taş bilgisini tutar.

            if (element.Contains("b"))
            {
                opponent = "s";
                element = element.Replace("b", "");
            }
            else
            {
                opponent = "b";
                if (!element.Equals("ss"))
                    element = element.Replace("s", "");
                else
                    element = "s";
            }
            
            // Taşların puan tablosu
            switch (element)
            {
                case "p":
                    score = 1;
                    break;
                case "a":
                    score = 3;
                    break;
                case "f":
                    score = 3;
                    break;
                case "k":
                    score = 5;
                    break;
                case "v":
                    score = 9;
                    break;
                case "s":
                    score = 100;
                    break;
                default:
                    break;
            }

            if (opponent.Equals("b"))
                element += "s";
            else
                element += "b";

            //Kale tarafından tehdit kontrolü
            boardElement = "k" + opponent;
            Rook rook = new Rook();
            rook.setElement(element);
            rook.setBoardElement(boardElement);
            rook.setX(i);
            rook.setY(j);
            rook.setScore(score);
            rook.setBoard(board);
            finalScore = Rook.CheckRook();
            if ((score - finalScore) > 0.0000001)
                return finalScore;


            //Fil tarafından tehdit kontrolü
            boardElement = "f" + opponent;
            Bishop bishop = new Bishop();
            bishop.setElement(element);
            bishop.setBoardElement(boardElement);
            bishop.setX(i);
            bishop.setY(j);
            bishop.setScore(score);
            bishop.setBoard(board);
            finalScore = Bishop.CheckBishop();
            if ((score - finalScore) > 0.0000001)
                return finalScore;

            //Vezir tarafından tehdit kontrolü
            boardElement = "v" + opponent;
            bishop.setElement(element);
            bishop.setBoardElement(boardElement);
            bishop.setX(i);
            bishop.setY(j);
            bishop.setScore(score);
            bishop.setBoard(board);
            finalScore = Bishop.CheckBishop();
            if ((score - finalScore) > 0.0000001)
                return finalScore;

            rook.setElement(element);
            rook.setBoardElement(boardElement);
            rook.setX(i);
            rook.setY(j);
            rook.setScore(score);
            rook.setBoard(board);
            finalScore = Rook.CheckRook();
            if ((score - finalScore) > 0.0000001)
                return finalScore;

            //Kral tarafından tehdit kontrolü
            boardElement = "s" + opponent;
            King king = new King();
            king.setElement(element);
            king.setBoardElement(boardElement);
            king.setX(i);
            king.setY(j);
            king.setScore(score);
            king.setBoard(board);
            finalScore = King.CheckKing();
            if ((score - finalScore) > 0.0000001)
                return finalScore;

            //Piyon tarafından tehdit kontrolü
            boardElement = "p" + opponent;
            Pawn pawn = new Pawn();
            pawn.setBoardElement(boardElement);
            pawn.setX(i);
            pawn.setY(j);
            pawn.setScore(score);
            pawn.setBoard(board);
            finalScore = Pawn.CheckPawn();
            if ((score - finalScore) > 0.0000001)
                return finalScore;

            //At tarafından tehdit kontrolü
            boardElement = "a" + opponent;
            Knight knight = new Knight();
            knight.setBoardElement(boardElement);
            knight.setX(i);
            knight.setY(j);
            knight.setScore(score);
            knight.setBoard(board);
            finalScore = Knight.CheckKnight();
            if ((score - finalScore) > 0.0000001)
                return finalScore;


            return finalScore;
        }
    }
}
