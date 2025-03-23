using Microsoft.JSInterop;
using Portfolio.BaseClasses;



namespace Portfolio.Pages
{
    public partial class Game
    {

        //Decalration
        private int _playerPoint = 0;
        private int _computerPoint = 0;
        private int _setPointPlayer = 0;
        private int _setPointComputer = 0;


        private string _playerSide = string.Empty;
        private string _computerSide = string.Empty;

        private int _firstSetResultPlayer = 0;
        private int _firstSetResultComputer = 0;

        private bool _isPlayerWin = false;
        private bool _isServeFinished = false;

        private bool _isServe = true;
        private string flagType = string.Empty;
        private string _coutColor = string.Empty;

        private bool _visibleDialog;

        private enum CourtSide
        {
            Right,
            Center,
            Left
        }
        //End Declaration


        protected override void OnInitialized()
        {
            _coutColor = PlayerInfoServices.PlayerInfo.CourtTypeEnum switch
            {
                Player.CourtType.grass => "#228B22",
                Player.CourtType.hard => "#1E90FF",
                Player.CourtType.clay => "#D2691E"
            };

        }


        private async Task MoveBallWhenServe(string position)
        {
            await IJSRuntime.InvokeVoidAsync("moveBallWhenServe", position);
            await Task.Delay(300);
        }

        private async Task CompServeBall(string position)
        {
            await IJSRuntime.InvokeVoidAsync("moveBallWhenHit", position);
            await Task.Delay(300);
        }

        private async Task SetTheBallForComputerServe()
        {
            await IJSRuntime.InvokeVoidAsync("setTheBallForComputer");
        }

        private async Task MoveRacketToHit(string position, bool isItPlayerRacket)
        {
            await IJSRuntime.InvokeVoidAsync("moveRacketToHit", position, isItPlayerRacket);
            await Task.Delay(300);

        }


        private async Task ServeOrHit(string playerValue, bool isServe)
        {
            if (isServe == true)
            {
                await ServeTheBall(playerValue);
                await MoveBallWhenServe(playerValue);
                await MoveRacketToHit(_computerSide, false);
                //bring back ball to the center
                await MoveBallWhenServe(string.Empty);
                if (!_isServe)
                {
                    await Task.Delay(1000);
                    await SetTheBallForComputerServe();
                }
            }
            else
            {
                await HitTheBall(playerValue);
                await CompServeBall(_computerSide);
                await MoveRacketToHit(playerValue, true);
                await SetTheBallForComputerServe();
                if (_isServe)
                {
                    await Task.Delay(1000);
                    await MoveBallWhenServe(string.Empty);
                }

            }

        }


        private async Task ServeTheBall(string value)
        {

            do
            {
                _playerSide = (value == string.Empty ? RandomSideMethod() : value);
                _computerSide = RandomSideMethod();

                if (!_playerSide.Contains(_computerSide))
                {
                    //Player get the point, comp , missed the side
                    if (_playerPoint >= 60)
                    {
                        TwoPointsWin(true);
                    }
                    else
                    {
                        CalculatePoints(_isPlayerWin = true);
                        _isServeFinished = true;
                    }
                }
                else
                {
                    if (_playerPoint >= 60)
                    {
                        TwoPointsWin(false);
                    }
                    else
                    {
                        //Comp get point
                        CalculatePoints(_isPlayerWin = false);
                        _isServeFinished = true;
                    }

                }

                value = string.Empty;

            } while (!_isServeFinished);


        }



        private async Task HitTheBall(string value)
        {
            do
            {
                _computerSide = RandomSideMethod();
                _playerSide = (value == string.Empty ? RandomSideMethod() : value);

                if (!_computerSide.Contains(_playerSide))
                {
                    //Player get the point, comp , missed the side
                    if (_computerPoint >= 60)
                    {
                        TwoPointsWin(false);

                    }
                    else
                    {
                        CalculatePoints(_isPlayerWin = false);
                        _isServeFinished = true;
                    }
                }
                else
                {

                    if (_playerPoint >= 60)
                    {
                        TwoPointsWin(true);
                    }
                    else
                    {
                        //Comp get point
                        CalculatePoints(_isPlayerWin = true);
                        _isServeFinished = true;
                    }

                }

                value = string.Empty;

            } while (!_isServeFinished);
        }



        private void CalculatePoints(bool isPlayerWinValue)
        {
            if (_playerPoint == 45 || _computerPoint == 45)
            {

                if (_computerPoint >= 45 && _playerPoint >= 45)
                {
                    TwoPointsWin(isPlayerWinValue);
                }
                else if (_playerPoint == 45 && isPlayerWinValue == true)
                {
                    SetPointWin(isPlayerWinValue);

                    if (_setPointPlayer > 6)
                    {
                        FullSetWin();
                    }
                }
                else if (_computerPoint == 45 && isPlayerWinValue == false)
                {

                    SetPointWin(isPlayerWinValue);

                    if (_setPointComputer > 6)
                    {
                        FullSetWin();
                    }
                }
                else
                {
                    CalculationPoints(isPlayerWinValue);
                }

            }
            else
            {
                CalculationPoints(isPlayerWinValue);

            }
        }




        private void SetPointWin(bool isPlayerWin)
        {

            if (isPlayerWin == true)
            {
                _setPointPlayer += 1;
                SetHitOrServe(_isServe);
            }
            else
            {
                _setPointComputer += 1;
                SetHitOrServe(_isServe);
            }

            _playerPoint = _computerPoint = 0;

        }




        private void TwoPointsWin(bool isPlayerWinValue)
        {

            if (isPlayerWinValue == true)
            {
                _playerPoint += 15;
            }
            else
            {
                _computerPoint += 15;
            }

            if (_playerPoint > 60 || _computerPoint > 60)
            {
                AdvantageSetPointWin();

            }
        }

        private void AdvantageSetPointWin()
        {

            if (_playerPoint > 60)
            {
                SetPointWin(true);
            }
            else
            {
                SetPointWin(false);
            }

            if (_setPointPlayer > 6 || _setPointComputer > 6)
            {
                FullSetWin();
            }

        }

        private void FullSetWin()
        {
            _firstSetResultComputer = _setPointComputer;
            _firstSetResultPlayer = _setPointPlayer;

            if (_setPointPlayer > 6 || _setPointComputer > 6)
            {
                _visibleDialog = true;

            }

            _playerPoint = _computerPoint = _setPointComputer = _setPointPlayer = 0;


        }


        private void CalculationPoints(bool isPlayerWin)
        {
            switch (isPlayerWin)
            {
                case true:
                    _playerPoint += 15;
                    break;
                case false:
                    _computerPoint += 15;
                    break;

            }
        }

        private string RandomSideMethod()
        {
            Random random = new Random();
            return ((CourtSide)(random.Next(0, 3))).ToString();
        }


        private void SetHitOrServe(bool initialValue)
        {
            if (initialValue == true)
            {
                _isServe = false;
            }
            else
            {
                _isServe = true;
            }

        }

        private async Task RestartGame()
        {
            _playerPoint = _computerPoint = _setPointComputer = _setPointPlayer  = 0;
            _firstSetResultComputer = _firstSetResultPlayer = 0;
            _visibleDialog = false;
            await MoveBallWhenServe(string.Empty);
            _isServe = true;
        }


  
    }
}
