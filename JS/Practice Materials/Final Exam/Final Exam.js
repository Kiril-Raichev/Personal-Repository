function result(array) {

    let string = array.shift();

    while (array != "End") {
        let current = array.shift().split(" ");

        switch (current[0]) {
            case "Translate":

                for (let letter of string) {
                    if (letter === current[1]) {
                        let replaced = string.replace(current[1], current[2]);
                        string = replaced;
                    }
                }
                console.log(string);
                break;
            case "Includes":
                if (string.includes(current[1])) {
                    console.log("True")
                } else {
                    console.log("False")
                }
                break;
            case "Start":
                let newString = string.split(" ")
                if (newString[0] === current[1]) {
                    console.log("True")
                } else {
                    console.log("False")
                }
                break;
            case "Lowercase":
                let newStringToLower = string.toLowerCase();
                string = newStringToLower;
                console.log(string);
                break;
            case "FindIndex":
                let biggestIndex = 0;
                let stringAsArray = string.split("");
                let length = stringAsArray.length;
                for (let i = 0; i < length; i++) {
                    if (stringAsArray[i] === current[1]) {
                        if (i > 0) {
                            biggestIndex = i;
                        }
                    }
                }
                console.log(biggestIndex);
                break;
            case "Remove": {
                let stringArray = string.split("");
                let removedString = stringArray.splice(current[1], current[2]).join("");
                let final = stringArray.join("")
                string = final;
                console.log(string);
                break;
            }
        }

    }
}
result([
    "*S0ftUni is the B3St Plac3**",
    "Translate 2 o",
    "Includes best",
    "Start the",
    "Lowercase",
    "FindIndex p",
    "Remove 2 7",
    "End"
    
]);
