function result(array) {
    let heroes = [];
    for (let heroInfo of array) {
        let [name, level, items] = heroInfo.split(" / ");

       let splittedd = items.split(', ');
       splittedd.sort((a, b) => a.localeCompare(b));
       splitted = splittedd.join(", ");

        let hero = {
            name: name,
            level: +level,
            items: splitted
        };

        heroes.push(hero);
    }
    let sorted = heroes.sort((a,b)=> a.level - b.level);

    sorted.forEach(el=>{
        console.log(`Hero: ${el.name}`)
        console.log(`level => ${el.level}`)
        console.log(`items => ${el.items}`)
    })
}
result([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]
)