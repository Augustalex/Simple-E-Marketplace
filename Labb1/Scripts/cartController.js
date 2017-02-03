///<reference path="Bacon.js" />

function Observable() {

    var listeners = [];
    var value;

    this.set = function (newValue) {
        var oldValue = this.value;
        this.value = newValue;
        activateListeners(this, oldValue, newValue);
    }

    function activateListeners(observable, oldValue, newValue) {
        
    }
}

function Cart(cartId) {
    this.cartId = cartId;
    this.items = [];
}

function CartController(cart, view) {
    this.cart = cart;
    this.view = view;

    /**
     * Takes variable number of arguments.
     * @returns {} 
     */
    this.add = function() {
        for (var i = 0; i < arguments.length; i++)
            this.cart.items.push(arguments[i]);
    }

    /**
     *  Takes variable number of arguments.
     *  The paramater is the object to be removed and not
     *  the index of the object.
     * @returns {} 
     */
    this.remove = function() {
        for (var i = 0; i < arguments.length; i++)
            this.cart.items.splice(this.cart.items.indexOf(arguments[i]), 1);
    }

    /**
     * Returns the reference to an item in this cart controller. (No copy)
     * @param {} index 
     * @returns {PickedItem}
     */
    this.get = function(index) {
        return this.cart.items[index];
    }

    /**
     * Returns an array of deep copies of all items in this cart.
     * @returns {PickedItem[]} 
     */
    this.getAll = function() {
        var collection = [];

        for (var i = 0; i < this.cart.items.length; i++)
            collection.push(this.cart.items[i].copy());

        return collection;
    }
    
}

function REST() {
    
}

function CartItem(cartId, itemId, quantity) {
    this.cartId = cartId;
    this.itemId = itemId;
    this.quantity = quantity;
}

function PickedItem(itemId, quantity) {
    this.itemId = itemId;
    this.quantity = quantity;

    this.copy = function() {
        return new PickedItem(this.itemId, this.quantity);
    }
}

function bindButtons(buttonContainer, cartView) {
    $(buttonContainer)
        .asEventStream("click", ".buyItemButton")
        .map(function (event, args) {
            return $.post("api/cart/", event.currentTarget.data("id"));
        }).done(function(view) {
            cartView.innerHTML = view;
        });
}

var CartProxy = {
    post: function(cart) {
        return $.post("api/cart", cart);
    }
};