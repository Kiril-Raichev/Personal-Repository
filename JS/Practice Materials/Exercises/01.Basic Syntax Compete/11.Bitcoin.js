function result(input) {
    let bitcoin = 11949.16;
    let gold = 67.51;
    let saved = 0;
    let bAmount = 0;
    let day = 0;
    let profit = 0;
    for (let i = 1; i < input.length + 1; i++) {
        if (i % 3 === 0) {
            profit = Number(input[i - 1] * gold);
            saved += profit * 0.7;
        } else {
            profit = Number(input[i - 1] * gold);
            saved += profit;
        }
        while (saved >= bitcoin) {
            saved -= bitcoin;
            if (bAmount === 0) {
                bAmount++;
                day = i;
            } else {
                bAmount++;
            }
        }

    }
    console.log(`Bought bitcoins: ${bAmount}`)
    if (bAmount !== 0) {
        console.log(`Day of the first purchased bitcoin: ${day}`)
    }
    console.log(`Left money: ${saved.toFixed(2)} lv.`)
}
result([3124.15,504.212,2511.124])