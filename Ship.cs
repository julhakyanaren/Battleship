using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public enum Ship
    {
        None = 'n',                 //0

        PlayerFrigate = 'F',        //1
        PlayerDestroyer = 'D',      //2
        PlayerCruiser = 'C',        //3
        PlayerBattleship ='B',      //4
        PlayerHit = 'H',            //?
        PlayerSunken = 'S',         //?
        PlayerEmpty = 'E',          //?
        PlayerMine = 'M',           //?

        EnemyFrigate = 'f',         //1
        EnemyDestroyer = 'd',       //2
        EnemyCruiser = 'c',         //3
        EnemyBattleship = 'b',      //4
        EnemyHit = 'h',             //?
        EnemySunken = 's',          //?
        EnemyEmpty = 'e',           //?
        EnemyMine = 'm'             //?
    }
}
