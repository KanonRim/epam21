class Service {

    vocabulary = new Map;
    lastID = -1;

    add(obj) {
        this.lastID += 1;

        if (typeof (obj) == 'object') {
            this.vocabulary.set(this.lastID, obj);
        }
        else {
            console.error("obj is not Object");
        }

    }

    getById(id) {
        if (this.vocabulary.has(id)) {
            let obj = this.vocabulary.get(id);
            return Object.assign({}, obj);;
        }
        console.error("object with id not found");
        return null;

    }

    getAll() {
        return new Map(this.vocabulary);
    }
    deleteById(id) {
        if (this.vocabulary.has(id)) {
            let obj = this.vocabulary.get(id);
            this.vocabulary.delete(id);
            return obj;
        }
        console.error("object with id not found");
        return null;
    }

    updateById(id, obj) {
        if (this.getById(id)) {
            if (typeof (obj) == 'object') {
                Object.assign(this.vocabulary.get(id), obj);
            }
            else {
                console.error("obj is not Object")
            }
        }


    }
    
    replaceById(id, obj) {
        if (this.getById(id)) {
            this.vocabulary.set(id, obj);
        }

    }

}
var storage = new Service();

storage.add({ name: "roma", age: 25 });

storage.updateById('', { name: "egor" });

console.log(storage.getById(0));

