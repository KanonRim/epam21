function calculator(str) {

    if (str == '')
        return 0;

    const regexNumber = /(\d+(?:\.\d+)?)/g;
    const regexОperations = /(\+|-|\*|\/)/g;

    let number = str.match(regexNumber);
    let operations = str.match(regexОperations);
    let result = number[0];

    if (number.length + 1 != operations.length) {
        console.error("not enough variables")
        return 0;
    }

    for (let index = 0; index < operations.length; index++) {
        switch (operations[index]) {
            case "+":
                result -= -number[index + 1];
                break;
            case "-":
                result -= number[index + 1];
                break;
            case "*":
                result *= number[index + 1];
                break;
            case "/":
                if (result == 0) {
                    console.error("Division by zero")
                }
                result /= number[index + 1];
                break;
            default:
                console.error("Error: unknown operation")

        }
    }
    return result;
}

const str = `1+2-4/4*45.28*10-100+200+13=`;
console.log(calculator(str));