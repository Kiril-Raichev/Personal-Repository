function result(base, increment) {
    let height = base / 2;
    let umHeight = height.toFixed(0);
    let numHeight = Number(umHeight);
    let buffer = numHeight + 1;
    let stone = 0;
    let marble = 0;
    let lapis = 0;
    let gold = 0;
    for (let i = 1; i < buffer; i++) {

        if (i === numHeight) {
            if (height % 2 === 0) {
                gold = 4 * increment;
            } else {
                gold = 1 * increment;
            }
        } else if (i % 5 === 0) {
            lapis += (4 * (base - 1))*increment;
            stone += ((base - 2) * (base - 2))*increment;
        } else {
            marble += (4 * (base - 1))*increment;
            stone += ((base - 2) * (base - 2))*increment;
        }

        base -= 2;

    }
    let sstone = Math.ceil(stone);
    let mmarble = Math.ceil(marble);
    let llapis = Math.ceil(lapis);
    let ggold = Math.ceil(gold);
    let fHeight = Math.floor(increment*numHeight)
    console.log(`
    Stone required: ${sstone}
    Marble required: ${mmarble}
    Lapis Lazuli required: ${llapis}
    Gold required: ${ggold}
    Final pyramid height: ${fHeight}
    `)

   

}
result(23, 0.5)