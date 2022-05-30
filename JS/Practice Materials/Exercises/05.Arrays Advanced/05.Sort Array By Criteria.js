function result(array) {

    let sortedByLength = array.sort((a, b) => a.length - b.length);

    for (let el in sortedByLength) {
        for (let i = 0; i < sortedByLength.length; i++) {
            if (el.length == sortedByLength[i].length) {
                let test = el.localeCompare(sortedByLength[i]);
                if (test != -1) {
                    let elIndex = sortedByLength.indexOf(el);
                    let buffer = sortedByLength[elIndex];
                    sortedByLength[elIndex] = sortedByLength[i];
                    sortedByLength[i] = buffer;
                }
            }
        }
    }
    for(let el of sortedByLength){
        console.log(el);
    }

}
result(
    ['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']

);