async function Buy(routeInstanceId, urlAction, outElementId, locale) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: urlAction,
            data: { routeInstanceId: routeInstanceId },
            dataType: "text",
            success: function (totalPrice) {
                ChangeTotalPriceInformation(outElementId, locale, totalPrice);
                resolve();
            },
            error: function (req, status, error) {
                $(outElementId).text('error during buying!');
                reject(error);
            }
        });
    });
}

async function BuyTwice(routeInstanceId1, routeInstanceId2, urlAction, outElementId, locale) {
    try {
        await Buy(routeInstanceId1, urlAction, outElementId, locale);

        await Buy(routeInstanceId2, urlAction, outElementId, locale);
    } catch (error) {
        console.error(error);
    }
}

function ChangeTotalPriceInformation(outElementId, locale, totalPrice) {
    $(outElementId).text(parseFloat(totalPrice).toLocaleString(locale,
        {
            style: "currency",
            currency: "CZK",
            minimumFractionDigits: 2,
            maximumFractionDigits: 2
        }));
}
