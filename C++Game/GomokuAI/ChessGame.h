#pragma once
#include "Man.h"
#include "Ai.h"
#include "Chess.h"
class ChessGame
{
public:
	ChessGame(Man* man, Ai* ai, Chess* chess);
	void play(); //game start

private:
	Man* man;
	Ai* ai;
	Chess* chess;
};

