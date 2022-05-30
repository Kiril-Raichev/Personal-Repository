function result(text) {

    let result = [];
    for (let element of text.split(" ")) {
        if (element[0] === "#" && element.length !== 1) {
            result.push(element.substring(1));   //stringMDN za methodi s string
        }
    }
    let final = []

    for (let el of result) {
        let array = el.split('');
        let arrL = array.length;
        let flag = true;
        for (let i = 0; i < arrL; i++) {
            let current = array[i].charCodeAt(0);
            if ((current < 97 || current > 122) &&
                (current < 65 || current > 90)) {
                flag = false;
            }
        }
        if (flag) {
            final.push(el);
        }
    }
    final.forEach(el=>console.log(el))
}
result(
    'Nowadays everyone uses # to tag a #special word in #socialMedia'
)