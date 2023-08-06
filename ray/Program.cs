// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the MPL-2.0.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

using System.Numerics;

namespace Raylib_CsLo.Examples.Shapes;

/*******************************************************************************************
*
*   raylib [shapes] example - bouncing ball
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2013 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class BoundingBall
{

    public static int main()
    {
        // Initialization
        //---------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        Raylib.InitWindow(screenWidth, screenHeight, "raylib [shapes] example - bouncing ball");

        Vector2 ballPosition = new Vector2(Raylib.GetScreenWidth() / 2.0f, Raylib.GetScreenHeight() / 2.0f);
        Vector2 ballSpeed = new Vector2(5.0f, 4.0f);
        int ballRadius = 20;

        bool pause = false;
        int framesCounter = 0;

        Raylib.SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
                                        //----------------------------------------------------------

        // Main game loop
        while (!Raylib.WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update
            //-----------------------------------------------------
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)) pause = !pause;

            if (!pause)
            {
                ballPosition.X += ballSpeed.X;
                ballPosition.Y += ballSpeed.Y;

                // Check walls collision for bouncing
                if ((ballPosition.X >= (Raylib.GetScreenWidth() - ballRadius)) || (ballPosition.X <= ballRadius)) ballSpeed.X *= -1.0f;
                if ((ballPosition.Y >= (Raylib.GetScreenHeight() - ballRadius)) || (ballPosition.Y <= ballRadius)) ballSpeed.Y *= -1.0f;
            }
            else framesCounter++;
            //-----------------------------------------------------

            // Draw
            //-----------------------------------------------------
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Raylib.RAYWHITE);

            Raylib.DrawCircleV(ballPosition, (float)ballRadius, Raylib.MAROON);
            Raylib.DrawText("PRESS SPACE to PAUSE BALL MOVEMENT", 10, Raylib.GetScreenHeight() - 25, 20, Raylib.LIGHTGRAY);

            // On pause, we draw a blinking message
            if (pause && ((framesCounter / 30) % 2) != 0) Raylib.DrawText("PAUSED", 350, 200, 30, Raylib.GRAY);

            Raylib.DrawFPS(10, 10);

            Raylib.EndDrawing();
            //-----------------------------------------------------
        }

        // De-Initialization
        //---------------------------------------------------------
        Raylib.CloseWindow();        // Close window and OpenGL context
                              //----------------------------------------------------------

        return 0;
    }
}