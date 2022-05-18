'use strict';

const e = React.createElement;

const UpdateCart = ({ productId }) => {


    const [val, setVal] = React.useState(0);
    const [basket, updateBaket] = React.useState([]);

    const setVal2 = (v, d) => {        
        setVal(Number(v));

        const basketCopy = Object.assign([], basket);

        const existing = basketCopy.find((p) => {
            return p.id === productId;
        });

        if (!existing) {
            basketCopy.push({ id: productId, qty: v });
        }
        else {            
            existing.qty = v;     
        }

        updateBaket(basketCopy);
        localStorage.setItem('basket', JSON.stringify(basketCopy));
    };

    return (
        <div>
            {productId}
            <hr />
            <button onClick={() => {
                if(val > 0)
                  setVal2(val - 1)
            }} className="btn btn-outline-secondary btn-sm">-</button>
            <input type="number" min="0" onChange={(e) => { setVal2(e.target.value);}} value={val} style={{ width: '100px' }} />
            <button onClick={() => { setVal2(val + 1) }} className="btn btn-primary btn-sm">+</button>
        </div>
    );
}

//const domContainer = document.querySelector('#app');
//ReactDOM.render(e(GetInTouchForm), domContainer);

const domContainers = document.querySelectorAll('.rb-app');
domContainers.forEach((domContainer) => {   
    const productId = domContainer.getAttribute("data-product-id");
    const containerId = domContainer.getAttribute("id");

    console.log(productId, containerId);

    //ReactDOM.render(e(UpdateCart), domContainer);

    ReactDOM.render(<UpdateCart productId={productId} /> , document.querySelector(`#${containerId}`));
});
