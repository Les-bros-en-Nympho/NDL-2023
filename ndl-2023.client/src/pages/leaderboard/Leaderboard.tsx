// Leaderboard.jsx

import '../../styles/leaderboard/leaderboard.scss';
import { Link } from 'react-router-dom';

export const Leaderboard = () => {
    return (
        <div className="leaderboard">
        <div className="leaderboard-header">Leaderboard</div>
        <ul className="leaderboard-list">
          <li className="leaderboard-item">
            <span className="medal">
              <Link to="">
                <img src="/images/gold-medal.png" alt="Gold Medal" />
              </Link>
            </span>
            <span>1</span>
            <span>Player1</span>
            <span>1000</span>
          </li>
          <li className="leaderboard-item">
            <span className="medal">
              <img src="silver-medal.png" alt="Silver Medal" />
            </span>
            <span>2</span>
            <span>Player2</span>
            <span>950</span>
          </li>
          <li className="leaderboard-item">
            <span className="medal">
              <img src="bronze-medal.png" alt="Bronze Medal" />
            </span>
            <span>3</span>
            <span>Player3</span>
            <span>900</span>
          </li>
          <li className="leaderboard-item">
            <span>4</span>
            <span>Player4</span>
            <span>850</span>
          </li>
          <li className="leaderboard-item">
            <span>5</span>
            <span>Player5</span>
            <span>800</span>
          </li>
        </ul>
      </div>
    )
};