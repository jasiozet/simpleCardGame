namespace App

open Feliz
open Feliz.DaisyUI
open Logic

type Components =
  [<ReactComponent>]
  static member Card(cardLogic, cardIsPicked) =
    Html.div [
      prop.classes [ "w-96" ]
      prop.children [
        Daisy.card [
          card.bordered
          card.full
          prop.children [
            Html.figure [
              Html.img [ prop.src cardLogic.img ]
            ]
            Daisy.cardBody [
              prop.style [
                style.alignItems.center
              ]
              prop.children [
                Daisy.cardTitle cardLogic.title
                Html.p cardLogic.ability
                Html.p cardLogic.alternative
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
    ]

  [<ReactComponent>]
  static member CardsHand(cards: Card List) =
    let (cardPicked, chooseCard) = React.useState (0)
    let whichCardWasPicked number _ = chooseCard (number)

    Html.div [
      Html.text (
        if cardPicked > 0 then
          $"Picked card: #{cardPicked}"
        else
          "Pick a card"
      )
      Html.div [
        prop.style [
          style.display.flex
          style.flexDirection.row
          style.flexWrap.nowrap
        ]
        prop.children [
          for card in cards do
            Components.Card(card, (whichCardWasPicked card.id))
        ]
      ]
    ]

  [<ReactComponent>]
  static member GameContainer() =
    Html.div [
      Components.CardsHand(Logic.exampleCards)
    ]