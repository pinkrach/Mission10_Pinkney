import { useEffect, useState } from 'react'
import './BowlerTable.css'

interface BowlerApiRecord {
  bowlerId: number
  bowlerLastName: string | null
  bowlerFirstName: string | null
  bowlerMiddleInit: string | null
  bowlerAddress: string | null
  bowlerCity: string | null
  bowlerState: string | null
  bowlerZip: string | null
  bowlerPhoneNumber: string | null
  team?: {
    teamId: number
    teamName: string
  } | null
}

function BowlerTable() {
  const [bowlers, setBowlers] = useState<BowlerApiRecord[]>([])
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    const baseUrl = import.meta.env.VITE_API_BASE_URL || 'http://localhost:5000'
    const url = `${baseUrl}/api/bowlers`

    fetch(url)
      .then((res) => {
        if (!res.ok) throw new Error(`Failed to fetch: ${res.status}`)
        return res.json()
      })
      .then((data: BowlerApiRecord[]) => {
        const marlinsOrSharks = data.filter(
          (b) => b.team?.teamName === 'Marlins' || b.team?.teamName === 'Sharks'
        )
        setBowlers(marlinsOrSharks)
      })
      .catch((err) => {
        console.error(err)
        setError(err.message)
      })
      .finally(() => setLoading(false))
  }, [])

  if (loading) return <p className="bowler-loading">Loading bowlers…</p>
  if (error) return <p className="bowler-error">Error: {error}</p>

  const formatName = (b: BowlerApiRecord) => {
    const parts = [b.bowlerFirstName, b.bowlerMiddleInit, b.bowlerLastName].filter(Boolean)
    return parts.join(' ')
  }

  return (
    <div className="bowler-table-container">
    <table className="bowler-table">
      <thead>
        <tr>
          <th>Bowler Name</th>
          <th>Team Name</th>
          <th>Address</th>
          <th>City</th>
          <th>State</th>
          <th>Zip Code</th>
          <th>Phone</th>
        </tr>
      </thead>
      <tbody>
        {bowlers.map((bowler) => (
          <tr key={bowler.bowlerId}>
            <td>{formatName(bowler)}</td>
            <td>{bowler.team?.teamName ?? ''}</td>
            <td>{bowler.bowlerAddress ?? ''}</td>
            <td>{bowler.bowlerCity ?? ''}</td>
            <td>{bowler.bowlerState ?? ''}</td>
            <td>{bowler.bowlerZip ?? ''}</td>
            <td>{bowler.bowlerPhoneNumber ?? ''}</td>
          </tr>
        ))}
      </tbody>
    </table>
    </div>
  )
}

export default BowlerTable
