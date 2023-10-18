#pragma once
#include<graphics.h>
#include<vector>
using namespace std;

//the location of chess
struct ChessPos {
	int row;
	int col;

	ChessPos(int r = 0, int c = 0):row(r), col(c){}
};

typedef enum {
	CHESS_WHITE = -1,
	CHESS_BLACK = 1
}chess_kind_t;

class Chess
{
public:
	Chess(int gradeSize, int marginX, int marginY, float chessSize);


	void init();
	bool clickBoard(int x, int y, ChessPos* Pos);
	void chessDown(ChessPos* pos, chess_kind_t kind);
	int getGradeSize(); // get the size of chess board

	int getChessData(ChessPos* pos);
	int getChessData(int row, int col);

	bool checkOver(); //check if the game is over

	

private:
	IMAGE chessBlackImg;
	IMAGE chessWhiteImg;

	int gradeSize; // the size of board
	int margin_x; //left size of board (21)
	int margin_y; //top size of board (19)
	float chessSize; // the size of chess(30)
	
	//save the statue of chess in current game 
	vector<vector<int>> chessMap;

	bool playerFlag;

	void updateGameMap(ChessPos* pos);

	bool checkWin(); //check if the game should over

	ChessPos lastPos;

};

