// Leaderboard.jsx

import '../../styles/leaderboard/leaderboard.scss';
import { Link } from 'react-router-dom';

import { API } from "../../services/API";
import { useState, useEffect } from 'react';

export const Leaderboard = () => {

    const [scores, setScores] = useState<any>([]);

    useEffect(() => {
      const fetchData = async () => {
        try {
          const response = await API.getInstance().get("/Score/leaderboard/5");

          console.log("First log : ", response);
          // Utilisez setScores pour mettre à jour l'état avec les données récupérées
          setScores(response);
        } catch (error) {
          console.error('Erreur lors de la récupération des données:', error);
        }
      };

      fetchData();
    }, []);

    useEffect(() => {
      // Cette fonction s'exécutera chaque fois que scores change
      console.log("Last log : ", scores);
    }, [scores]);

    return (
        <div className="leaderboard">
        <div className="leaderboard-header">Leaderboard</div>
        <ul className="leaderboard-list">
          <li className="leaderboard-item">
            <span className="medal">
              <Link to="">
                <img src="/images/gold_medal.png" alt="Gold Medal" />
              </Link>
            </span>
            <span>1</span>
            <span>{scores.length >= 1 ? scores[0]?.username ?? "Utilisateur non disponible" : "Utilisateur non disponible"}</span>
            <span>{scores.length >= 1 ? scores[0]?.score ?? "Score non disponible" : "Score non disponible"}</span>
          </li>
          <li className="leaderboard-item">
            <span className="medal">
              <Link to="">
                <img src="/images/silver_medal.png" alt="Silver Medal" />
              </Link>
            </span>
            <span>2</span>
            <span>{scores.length >= 2 ? scores[1]?.username ?? "Utilisateur non disponible" : "Utilisateur non disponible"}</span>
            <span>{scores.length >= 2 ? scores[1]?.score ?? "Score non disponible" : "Score non disponible"}</span>
          </li>
          <li className="leaderboard-item">
            <span className="medal">
              <Link to="">
                <img src="/images/bronze_medal.png" alt="Bronze Medal" />
              </Link>
            </span>
            <span>3</span>
            <span>{scores.length >= 3 ? scores[2]?.username ?? "Utilisateur non disponible" : "Utilisateur non disponible"}</span>
            <span>{scores.length >= 3 ? scores[2]?.score ?? "Score non disponible" : "Score non disponible"}</span>
          </li>
          <li className="leaderboard-item">
            <span className="medal">
              <Link to="">
                <img src="/images/honor_medal.png" alt="Honor Medal" />
              </Link>
            </span>
            <span>4</span>
            <span>{scores.length >= 4 ? scores[3]?.username ?? "Utilisateur non disponible" : "Utilisateur non disponible"}</span>
            <span>{scores.length >= 4 ? scores[3]?.score ?? "Score non disponible" : "Score non disponible"}</span>
          </li>
          <li className="leaderboard-item">
          <span className="medal">
              <Link to="">
                <img src="/images/honor_medal.png" alt="Honor Medal" />
              </Link>
            </span>
            <span>5</span>
            <span>{scores.length >= 5 ? scores[4]?.username ?? "Utilisateur non disponible" : "Utilisateur non disponible"}</span>
            <span>{scores.length >= 5 ? scores[4]?.score ?? "Score non disponible" : "Score non disponible"}</span>
          </li>
        </ul>
      </div>
    )
};