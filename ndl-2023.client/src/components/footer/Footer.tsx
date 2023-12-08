import { API } from "../../services/API"
import { useEffect } from "react"

export const Footer = () => {
    
    useEffect(() => {
        API.getInstance().get("/TrueOrFalse/random").then((res) => {
            console.log(res)
        });
    }, [])

    return (
        <footer>
        </footer>
    )
}