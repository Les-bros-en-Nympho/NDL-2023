import { API } from "../../services/API"
import { useEffect } from "react"

export const QuizzComponent = () => {

    let statement: string | null = "";

    function ReloadRandom(){
        let json = null
        API.getInstance().get("/TrueOrFalse/random").then((response) => {
            json = response;
        });
        statement = json;
    }
    const onComponentMount = () => {
        ReloadRandom();
    };

    useEffect(() => {
        onComponentMount();
    }, []);

    function Guess(response: string){
        let json = null;
        API.getInstance().get(`/TrueOrFalse/guess/${response}`).then((response) => {
           json = response;
        });
        ReloadRandom();
        return json;
    }

    function GuessAsFalse() {
        return Guess("false");
    }

    function GuessAsTrue() {
        return Guess("true");
    }

    return (
        <>
            <div className="box">
                <div className="button button-false" onClick={GuessAsFalse}>
                    <h1>FAUX</h1>
                </div>
                <div className="statement">
                    {statement}
                </div>
                <div className="button button-true" onClick={GuessAsTrue}>
                    <h1>VRAI</h1>
                </div>
            </div>
        </>
    )
}