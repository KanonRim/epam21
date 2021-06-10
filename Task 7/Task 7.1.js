String.prototype.MySplit = function (separator) {

    let splitText = [];

    let text = this;
    splitText = text.split(separator[0]);
    for (let index = 0; index < splitText.length; index++) {
        for (let j = 1; j < separator.length; j++) {
            let buf = splitText[index].toString().split(separator[j]);

            for (let bufIdex = 0; bufIdex < buf.length; bufIdex++) {
                if (buf[bufIdex] != '')
                    splitText.splice(index + bufIdex, 1, buf[bufIdex]);
            }

        }
    }
    return splitText;
}


function DublerRemover(text) {
    let separator = "?!:;,.     ".slice();


    let word = text.MySplit(separator);
    let charMasDubler = [];
    for (let index = 0; index < word.length; index++) {
        charMasDubler.push(DublerCharInText(word[index]));
    }
    return RemoverCharMas(text, charMasDubler)
}

function DublerCharInText(text) {
    let charMas = [];
    for (let index = 0; index < text.length; index++) {
        for (let j = index + 1; j < text.length; j++) {
            if (text[index] == text[j]) {
                charMas.push(text[j]);
            }
        }
    }
    return charMas;
}

function RemoverCharMas(text, char) {

    for (let index = 0; index < char.length; index++) {
        text = text.split(char[index]).join('');

    }
    return text;
}
console.log(DublerRemover("У попа была собака"));