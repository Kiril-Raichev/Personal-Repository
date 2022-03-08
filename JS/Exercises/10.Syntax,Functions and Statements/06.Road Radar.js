function result(a, b) {
    let speed = a;
    let place = b;
    let limit = 0;
    switch (b) {
        case "motorway":
            limit = 130;
            if (speed <= limit) {
                console.log(`Driving ${speed} km/h in a ${limit} zone`
                )
            } else {
                let overLimit = speed - limit;
                if ((overLimit) <= 20) {
                    console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - speeding`);
                } else if ((overLimit) <= 40) {
                    console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - excessive speeding`);
                } else {
                    console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - reckless driving`);
                }
            }
            break;
        case "interstate":
            limit = 90;
            if (speed <= limit) {
                console.log(`Driving ${speed} km/h in a ${limit} zone`
                )
            } else {
                let overLimit = speed - limit;
                if ((overLimit) <= 20) {
                    console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - speeding`);
                } else if ((overLimit) <= 40) {
                    console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - excessive speeding`);
                } else {
                    console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - reckless driving`);
                }
            }
            break;
        case "city":
            limit = 50;
            if (speed <= limit) {
                console.log(`Driving ${speed} km/h in a ${limit} zone`
                )
            } else {
                let overLimit = speed - limit;
                if ((overLimit) <= 20) {
                    console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - speeding`);
                } else if ((overLimit) <= 40) {
                    console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - excessive speeding`);
                } else {
                    console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - reckless driving`);
                }
            }
            break;
        case "residential":
            limit = 20;
            if (speed <= limit) {
                console.log(`Driving ${speed} km/h in a ${limit} zone`
                )
            } else {
                let overLimit = speed - limit;
                if ((overLimit) <= 20) {
                    console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - speeding`);
                } else if ((overLimit) <= 40) {
                    console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - excessive speeding`);
                } else {
                    console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - reckless driving`);
                }
            }
            break;

    }

}
result(
    40, 'city'
)