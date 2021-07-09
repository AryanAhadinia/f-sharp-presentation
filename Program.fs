// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

type Node =
    | DatalessNode
    | DatafulNode of value: int * left: Node * right: Node

let rec insert (r: Node) (v: int) : Node =
    match r with
    | DatalessNode -> DatafulNode(v, DatalessNode, DatalessNode)
    | DatafulNode (value = rootValue; right = rootRight; left = rootLeft) ->
        if v <= rootValue then
            DatafulNode(rootValue, (insert rootLeft v), rootRight)
        else
            DatafulNode(rootValue, rootLeft, (insert rootRight v))

let mutable root = DatalessNode

[<EntryPoint>]
let main argv =
    root <- (insert root 3)
    root <- (insert root 1)
    root <- (insert root 0)
    root <- (insert root 2)
    root <- (insert root 4)
    printfn "%A" root
    0 // return an integer exit code
