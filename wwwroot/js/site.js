
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
            ball.style.bottom = '';
            ball.style.left = '10%';
            ball.style.top = '2%';
            break;
        case 'Center':
            ball.style.bottom = '';
            ball.style.left = '40%';
            ball.style.top = '2%';
            break;
        case 'Right':
            ball.style.bottom = '';
            ball.style.left = '70%'; 
            ball.style.top = '2%';
            break;
        }
    }
}

function moveBallWhenHit(position)
{
  
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
    ball.style.top = '';
    ball.style.bottom = '85%';
    ball.style.left = '40%';

    racket.style.bottom = '';
    racket.style.left = '40%';
    racket.style.top = '80%';

}


function moveRacketToHit(position, isItPlayerRacketHit)
{

    if (isItPlayerRacketHit)
    {
        switch (position) {
            case 'Left':
                
                racket.style.left = '10%';
                racket.style.top = '75%';
                break;
            case 'Center':
                
                racket.style.left = '40%';
                racket.style.top = '70%';
                break;
            case 'Right':
                
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