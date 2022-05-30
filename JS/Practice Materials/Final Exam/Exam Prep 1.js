function result(input) {
    let password = input.shift();

    let commands = {
        "TakeOdd":(password)=>{
           
            return [...password]
            .filter((symbol,index) =>index % 2 !==0)
            .join("");
        },
        "Cut":(password,index,length)=>{
            index = +index;
            length = +length;

            let substring = password.substr(index,length);
            
            return password.replace(substring, "");
        },
        "Substitute":(password,substring,substitute)=>{
            if(password.includes(substring)){
                return password.replace(new RegExp(substring,"g"),substitute);
            }else{
                console.log("Nothing to replace!");
                return password;
            }


        }
    }
    input.forEach(line => {
        if(line !== "Done"){
            let[command,...tokens] = line.split(" ");
            let oldPassword = password;
            password = commands[command](password,...tokens);
            if(oldPassword!==password){
                console.log(password)
            }
        }
    });
    console.log(`Your password is: ${password}`);
    
}
result([
    "Siiceercaroetavm!:?:ahsott.:i:nstupmomceqr",
    "TakeOdd",
    "Cut 15 3",
    "Substitute :: -",
    "Substitute | ^",
    "Done"
])