
function moveBallWhenServe(position)
{
    var ball = document.getElementById('ball');
    var racket = document.getElementById('racket');

    if (!position)
    {
        ball.style.top = '';
        ball.style.left = '40%';
        ball.style.bottom = '2%';

        //Added racket to move center after it hits the ball
        racket.style.top = '2%';
        racket.style.left = '40%';

    }
    else {

    switch (position)
    {
        case 'Left':
            ball.style.left = '10%';
            ball.style.top = '2%';
            break;
        case 'Center':
            ball.style.left = '40%';
            ball.style.top = '2%';
            break;
        case 'Right':
            ball.style.left = '70%'; 
            ball.style.top = '2%';
            break;
        }
    }
}

function moveBallWhenHit(position)
{
   // var ball = document.getElementById('ball');
    switch (position) {
        case 'Left':
            ball.style.top = '';
            ball.style.left = '10%';
            ball.style.bottom = '2%';
            break;
        case 'Center':
            ball.style.top = '';
            ball.style.left = '40%';
            ball.style.bottom = '2%';
            break;
        case 'Right':
            ball.style.top = '';
            ball.style.left = '70%';
            ball.style.bottom = '2%';
            break;
    }
}

function setTheBallForComputer()
{
  
    ball.style.bottom = '75%';
    ball.style.left = '40%';
    ball.style.top = '';

    racket.style.bottom = '';
    racket.style.left = '40%';
    racket.style.top = '80%';

}


function moveRacketToHit(position, isItPlayerRacketHit)
{
   // var racket = document.getElementById('racket');

    if (isItPlayerRacketHit)
    {
        switch (position) {
            case 'Left':
                //racket.style.top = '';
                racket.style.left = '10%';
                racket.style.top = '75%';
                break;
            case 'Center':
                //racket.style.top = '';
                racket.style.left = '40%';
                racket.style.top = '65%';
                break;
            case 'Right':
                //racket.style.top = '';
                racket.style.left = '70%';
                racket.style.top = '75%';
                break;
        }
    } else
    {
        switch (position)
        {
            case 'Left':
                racket.style.bottom = '';
                racket.style.top = '2%';
                racket.style.left = '10%';

                break;
            case 'Center':
                racket.style.bottom = '';
                racket.style.top = '9%';
                racket.style.left = '40%';

                break;
            case 'Right':
                racket.style.bottom = '';
                racket.style.top = '2%';
                racket.style.left = '70%';

                break;
        }
    }
}