function result(arr) {
    let phones = arr.shift().split(", ");
    let commands = arr;
    for (i = 0; i < commands.length; i++) {
        let current = commands[i].split(' ');
        switch (current[0]) {
            case "Add":
                if (!phones.includes(current[2])) {
                    phones.push(current[2]);
                }
                break;
            case "Remove":
                if (phones.includes(current[2])) {
                    let index = phones.indexOf(current[2]);
                    phones.splice(index, 1);
                }
                break;
            case "Bonus":
                let curr = current[3].split(':');
                if (phones.includes(curr[0])) {
                    let index = phones.indexOf(curr[0]);
                    phones.splice(index + 1, 0, curr[1]);
                }
                break;
            case "Last":
                if (phones.includes(current[2])) {
                    let index = phones.indexOf(current[2]);
                    let temp = phones.splice(index, 1).join(' ');
                    phones.push(temp);
                }
                break;
            default:
                break;
        }
    }
    console.log(phones.join(", "));
}
result([
    "SamsungA50, MotorolaG5, IphoneSE",
    "Add - Iphone10",
    "Remove - IphoneSE",
    "End"
]);