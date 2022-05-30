function test(input) {
    let heroesNumber = +input.shift();

    let heroes = {};

    while (heroesNumber > 0) {
        let line = input.shift().split(' ');
        let heroName = line[0];
        let hp = +line[1];
        let mp = +line[2];

        if (hp > 100) {
            hp = 100;
        }
        if (mp > 200) {
            mp = 200
        }

        heroes[heroName] = [hp, mp];

        heroesNumber--;
    }
    let [command, hero, amount, name] = input.shift().split(" - ")


    while (command !== "End") {
        switch (command) {

            case "CastSpell":

                if (heroes.hasOwnProperty(hero)) {
                    let currentHeroArray = heroes[hero];
                    let currentMP = currentHeroArray[1];
                    amount = +amount;
                    if (currentMP >= amount) {
                        currentMP -= amount;
                        currentHeroArray[1] = currentMP;
                        heroes[hero] = currentHeroArray;
                        console.log(`${hero} has successfully cast ${name} and now has ${currentMP} MP!`)
                    } else {
                        console.log(`${hero} does not have enough MP to cast ${name}!`)
                    }
                }
                break;

            case "TakeDamage":
                if (heroes.hasOwnProperty(hero)) {
                    let currentHeroArray = heroes[hero];
                    let currentHP = currentHeroArray[0];
                    amount = +amount;
                    currentHP -= amount;
                    if (currentHP > 0) {
                        currentHeroArray[0] = currentHP;
                        heroes[hero] = currentHeroArray;
                        console.log(`${hero} was hit for ${amount} HP by ${name} and has ${currentHP} left!`)
                    } else {
                        console.log(`${hero} has been killed by ${name}!`)
                        delete heroes[hero];
                    }
                }
                break;

            case "Recharge":
                if (heroes.hasOwnProperty(hero)) {
                    let currentHeroArray = heroes[hero];
                    let currentMP = currentHeroArray[1];
                    let needMP = 200 - currentMP;
                    amount = +amount;
                    currentMP += amount;

                    if (currentMP > 200) {
                        currentMP = 200;
                        amount = needMP;
                    }
                    currentHeroArray[1] = currentMP;
                    heroes[hero] = currentHeroArray;
                    console.log(`${hero} recharged for ${amount} MP!`)
                }
                break;

            case "Heal":
                if (heroes.hasOwnProperty(hero)) {
                    let currentHeroArray = heroes[hero];
                    let currentHP = currentHeroArray[0];
                    let needHP = 100 - currentHP;
                    amount = +amount;
                    currentHP += amount;

                    if (currentHP > 100) {
                        currentHP = 100
                        amount = needHP;
                    }
                    currentHeroArray[0] = currentHP;
                    heroes[hero] = currentHeroArray;
                    console.log(`${hero} healed for ${amount} HP!`)
                }
                break;
        }
        [command, hero, amount, name] = input.shift().split(" - ");
    }

    let heroesArray = Object.entries(heroes);
    let sortedHeroesArray = heroesArray.sort(sortHeroes);

    function sortHeroes (heroA,heroB){
        let heroNameA = heroA[0];
        let heroNameB = heroB[0];
        let heroPointsA = heroA[1];
        let heroPointsB = heroB[1];
        let heroHPA = heroPointsA[0];
        let heroHPB= heroPointsB[0];

        if(heroHPA === heroHPB){
            return heroNameA.localeCompare(heroNameB);
        }else{
            return heroHPB - heroHPA;
        }

    }
    let sortedHeroes = Object.fromEntries(sortedHeroesArray);
    
    for(let hero in sortedHeroes){
        console.log(hero);
        let heroPoints = sortedHeroes[hero];
        console.log(`  HP: ${heroPoints[0]}`)
        console.log(`  MP: ${heroPoints[1]}`)

    }

}
test(['2',
    'Solmyr 85 120',
    'Kyrre 99 50',
    'Heal - Solmyr - 10',
    'Recharge - Solmyr - 50',
    'TakeDamage - Kyrre - 66 - Orc',
    'CastSpell - Kyrre - 15 - ViewEarth',
    'End'])