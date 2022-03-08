function result(input) {
    let xpNeeded = input.shift();
    let battlesNum = input.shift();
    let xpPerBattle = input;
    let sum = 0;
    for (let i = 1; i < xpPerBattle.length + 1; i++) {
        if (i % 3 === 0) {
            xpPerBattle[i - 1] = xpPerBattle[i - 1] + (xpPerBattle[i - 1] * 15 / 100);
        } else if (i % 5 === 0) {
            xpPerBattle[i - 1] = xpPerBattle[i - 1] - xpPerBattle[i - 1] * 10 / 100;
        } else if (i % 15 === 0) {
            xpPerBattle[i - 1] = xpPerBattle[i - 1] + xpPerBattle[i - 1] * 5 / 100;
        }
        sum += xpPerBattle[i-1];
        if (sum >= xpNeeded) {
            console.log(`Player successfully collected his needed experience for ${i} battles.`);
            break;
        }
    }
    if(sum<xpNeeded){
        console.log(`Player was not able to collect the needed experience, ${(xpNeeded - sum).toFixed(2)} more needed. `)
    }
}
result([
    400,
    5,
    50,
    100,
    200,
    100,
    20
]);