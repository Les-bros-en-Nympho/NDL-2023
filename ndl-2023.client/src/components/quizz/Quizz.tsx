import { API } from "../../services/API"
import { useEffect, useState } from "react"

export const QuizzComponent = () => {

    const [statement, setStatement] = useState("");
    const [response, setResponse] = useState("");

    function ReloadRandom(){
        API.getInstance().get("/TrueOrFalse/random").then((response) => {
            if(response != null)
                setStatement((response as never)['question']);
        });
    }
    const onComponentMount = () => {
        ReloadRandom();
    };

    useEffect(() => {
        onComponentMount();
    }, []);

    function Guess(responseP: string){
        let json = null;
        API.getInstance().get(`/TrueOrFalse/guess/${responseP}`).then((response) => {
            console.log(response);
            if(response != null)
                setResponse((response as never)["explaination"]);
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
                <div className="yesno">
                    <div className="button button-false" onClick={GuessAsFalse}>
                        <h1>FAUX</h1>
                    </div>
                    <div className="button button-true" onClick={GuessAsTrue}>
                        <h1>VRAI</h1>
                    </div>
                </div>
                <div className="statement">
                    <p>
                        {statement}
                    </p>
                </div>
                <div>

                    <br></br>
                    <p className="response">
                        Réponse précédente : {response}
                    </p>
                </div>
            </div>
        </>
    )
}