namespace App

open Feliz
open Feliz.DaisyUI

type Components =
  [<ReactComponent>]
  static member Card(img: string, title: string, cardIsPicked) =
    Html.div [
      prop.classes [ "w-96" ]
      prop.children [
        Daisy.card [
          card.bordered
          card.full
          prop.children [
            Html.figure [
              Html.img [ prop.src img ]
            ]
            Daisy.cardBody [
              Daisy.cardTitle title
              Html.p "This will be a card text"
              Daisy.cardActions [
                Daisy.button.button [
                  prop.text "Pick"
                  button.primary
                  prop.onClick cardIsPicked
                ]
              ]
            ]
          ]
        ]
      ]
    ]

  [<ReactComponent>]
  static member CardsHand() =
    let (cardPicked, chooseCard) = React.useState (0)
    let whichCardWasPicked number _ = chooseCard (number)
    Html.div [
      Html.text (
        if cardPicked > 0 then
          $"You picked card: #{cardPicked}"
        else
          "Pick a card"
      )
      Html.div [
        prop.style [
          style.display.flex
          style.flexDirection.row
        ]
        prop.children [
          Components.Card(
            "https://cdn.britannica.com/55/174255-050-526314B6/brown-Guernsey-cow.jpg",
            "Cow",
            (whichCardWasPicked 1)
          )
          Components.Card(
            "https://previews.123rf.com/images/monticello/monticello1306/monticello130600032/20330858-brown-chicken-in-grass.jpg",
            "Chicken",
            (whichCardWasPicked 2)
          )
        ]
      ]
    ]