import { useEffect, useState } from 'react';
import type { Bowler } from './types/bowler';

function BowlingList() {
    const [bowlers, setBowlers] = useState<Bowler[]>([]);

    useEffect(() => {
        fetch('http://localhost:5197/api/Bowling')
            .then((res) => res.json())
            .then((data) => setBowlers(data));
    }, []);

    return (
        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Team</th>
                    <th>Address</th>
                    <th>City</th>
                    <th>State</th>
                    <th>Zip</th>
                    <th>Phone</th>
                </tr>
            </thead>
            <tbody>
                {bowlers.map((b) => (
                    <tr key={b.bowlerId}>
                        <td>{b.bowlerFirstName} {b.bowlerMiddleInit} {b.bowlerLastName}</td>
                        <td>{b.teamName}</td>
                        <td>{b.bowlerAddress}</td>
                        <td>{b.bowlerCity}</td>
                        <td>{b.bowlerState}</td>
                        <td>{b.bowlerZip}</td>
                        <td>{b.bowlerPhoneNumber}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}

export default BowlingList;
