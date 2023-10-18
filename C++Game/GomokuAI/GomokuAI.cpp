// GomokuAI.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "ChessGame.h"

int main(void)
{
    Man man;
    //Chess chess;
    Chess chess(18, 21, 19, 30);
    Ai ai;

    ChessGame game(&man, &ai, &chess);

  
    game.play();

    return 0;
}

