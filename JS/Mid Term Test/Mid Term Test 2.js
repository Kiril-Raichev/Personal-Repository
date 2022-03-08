function result(array) {
    let coffees = array.shift().split(' ');
    let commandNum = +array.shift();
    let commands = array;
    for (i = 0; i < commandNum; i++) {
        let current = commands[i].split(' ');
        if (current[0] === "Include") {
            coffees.push(current[1]);
        } else if (current[0] === "Remove") {
            if (coffees.length >= current[2]) {
                if (current[1] === "first") {
                    for (let j = 0; j < current[2]; j++) {
                        coffees.shift();
                    }
                } else {
                    for (let j = 0; j < current[2]; j++) {
                        coffees.pop();
                    }
                }
            } else {

            }
        } else if (current[0] === "Prefer") {
            if (current[1] && current[2] < coffees.length) {
                let temp = coffees[current[1]]
                coffees[current[1]] = coffees[current[2]];
                coffees[current[2]] = temp;
            }
        } else if (current[0] === "Reverse") {
            coffees.reverse();
        }
    }
    console.log("Coffees:")

    console.log(coffees.join(' '));
}
result([
    "Arabica Liberica Charrieriana Magnistipula Robusta BulkCoffee StrongCoffe",
    "5",
    "Include TurkishCoffee",
    "Remove first 2",
    "Remove last 1",
    "Prefer 3 1",
    "Reverse"
]);