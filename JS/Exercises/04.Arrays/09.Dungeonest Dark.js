function result(arr) {
    let currentHp = 100;
    let currentCoin = 0;
    let string = arr[0];
    let array = string.split('|');
    for (let i = 0; i < array.length; i++) {
        let current = array[i];
        let newArr = current.split(' ');

        if(currentHp <= 0){
            break;
        }

        if (newArr[0] == "potion") {
            let healing = Number(newArr[1]);
            if (currentHp == 100) {
                console.log(`You healed for ${0} hp.`)
            } else {
                let finalHp = currentHp + healing;
                if (finalHp >= 100) {
                    let diff = 100 - currentHp;
                    currentHp = 100;
                    console.log(`You healed for ${diff} hp.`)
                    console.log(`Current health: ${100} hp.`)
                } else {
                    console.log(`You healed for ${healing} hp.`)
                    console.log(`Current health: ${finalHp} hp.`)
                    currentHp = finalHp;
                }
            }
        } else if
            (newArr[0] == "chest") {
            let coin = Number(newArr[1]);
            currentCoin +=coin;
            console.log(`You found ${coin} coins.`)
        } else
        {
            let monster = newArr[0];
            let damage = Number(newArr[1]);
            currentHp -= damage;
            if(currentHp > 0){
                console.log(`You slayed ${monster}.`)
            }else{
                console.log(`You died! Killed by ${monster}.`)
                console.log(`Best room: ${i + 1}`)
            }
        }
    }
    if(currentHp > 0){
        console.log(`You've made it!`);
        console.log(`Coins: ${currentCoin}`);
        console.log(`Health: ${currentHp}`);
    }
}
result(["cat 10|potion 30|orc 10|chest 10|snake 25|chest 110"]
);