function result(lost, helmet, sword, shield, armor) {
    let helmetCount = 0;
    let swordCount = 0;
    let shieldCount = 0;
    let armorCount = 0;
    for (let i = 1; i <= lost; i++) {
        if (i % 2 === 0) {
            helmetCount++;
        }
        if (i % 3 === 0) {
            swordCount++;
        }
        if (i % 6 === 0) {
            shieldCount++;
        }
        if (i % 12 === 0) {
            armorCount++;
        }
    }
    let result = helmetCount * helmet + sword * swordCount + shield * shieldCount + armor * armorCount;
    console.log(`Gladiator expenses: ${result.toFixed(2)} aureus`);
}
result(
    7,
    2,
    3,
    4,
    5
);