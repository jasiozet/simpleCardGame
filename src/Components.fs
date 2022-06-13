namespace App

open Feliz
open Feliz.DaisyUI
open Logic

type Components =
  [<ReactComponent>]
  static member StaticCard(cardLogic) =
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
              prop.style [ style.alignItems.center ]
              prop.children [
                Daisy.cardTitle cardLogic.title
                Html.p cardLogic.ability
                Html.p cardLogic.alternative
              ]
            ]
          ]
        ]
      ]
    ]

  [<ReactComponent>]
  static member PickableCard(cardLogic, cardIsPicked) =
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
              prop.style [ style.alignItems.center ]
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
  static member CardsHand(cards: Card List, whichCardWasPicked) =
    Html.div [
      prop.style [
        style.display.flex
        style.flexDirection.row
        style.flexWrap.nowrap
      ]
      prop.children [
        for card in cards do
          Components.PickableCard(card, (whichCardWasPicked card.id))
      ]
    ]

  [<ReactComponent>]
  static member CardsTableu(cards: Card List) =
    Html.div [
      prop.style [
        style.display.flex
        style.flexDirection.column
        style.flexWrap.nowrap
      ]
      prop.children [
        for card in cards do
          Components.StaticCard(card)
      ]
    ]

  [<ReactComponent>]
  static member GameContainer() =
    let (cardsInTableu, setCardsInTableu) = React.useState (List.empty)
    let (cardPickedId, chooseCard) = React.useState (0)
    let whichCardWasPicked number _ =
      chooseCard(number)
      let cardPicked =
        Logic.exampleCards
        |> List.find (fun c -> c.id = number)
      setCardsInTableu(cardPicked :: cardsInTableu)

    Html.div [
      Html.div [
        Html.text (
          if cardPickedId> 0 then
            $"Picked card: #{cardPickedId}"
          else
            "Pick a card"
        )
        Components.CardsHand(Logic.exampleCards, whichCardWasPicked)
        Html.text "Your stack of cards (newer ones show at the top)"
        Components.CardsTableu(cardsInTableu)
      ]
    ]