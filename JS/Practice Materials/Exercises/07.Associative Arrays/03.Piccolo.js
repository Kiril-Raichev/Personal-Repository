function result(array) {

    let parking = {};

    for (let el of array) {
        let [command, car] = el.split(", ");
        if (command === "IN") {
            parking[car] = command;
        } else if (command === "OUT") {
            delete parking[car];
        }
    }
    let arrayOfNumbers = Object.keys(parking);
    let sort = arrayOfNumbers.sort((a, b) => a.localeCompare(b));

    if (sort === 0) {
        console.log("Parking lot is empty");
    }else {
        for (let el of sort) {
            console.log(el);
        }
        // ili 
        // console.log(sort.join("\n"))
        //joinvash gi na nov red
    }
}
result(
    ['IN, CA2844AA',
        'IN, CA1234TA',
        'OUT, CA2844AA',
        'IN, CA9999TT',
        'IN, CA2866HI',
        'OUT, CA1234TA',
        'IN, CA2844AA',
        'OUT, CA2866HI',
        'IN, CA9876HH',
        'IN, CA2822UU']
)